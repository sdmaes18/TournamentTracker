using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// Logic for creating a tournament.
    /// </summary>
    public static class TournamentLogic
    {
        // Order list of teams randomly.
        // Check if it's big enough - if not add in a bye.
        // Create the first round of matchups.
        // Create every round after that.

        /// <summary>
        /// Creates the rounds for the tournament. 
        /// </summary>
        /// <param name="model">Tournament to create rounds for.</param>
        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeams(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byeRounds = FindNumberOfByes(rounds, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byeRounds, randomizedTeams));

            CreateOtherRounds(model, rounds);
        }

        /// <summary>
        /// Updates the tournament.
        /// </summary>
        /// <param name="model">Tournament to update.</param>
        public static void UpdateTournamentResults(TournamentModel model)
        {
            int currentTournamentRound = model.CheckCurrentRound();

            List<MatchupModel> toScore = new List<MatchupModel>();

            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel rm in round)
                {
                    if (rm.Winner == null && (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
                    {
                        toScore.Add(rm);
                    }
                }
            }

            TournamentLogic.ScoreMatchups(toScore);

            TournamentLogic.AdvanceWinners(toScore, model);

            toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));

            int endingRound = model.CheckCurrentRound();

            if (endingRound > currentTournamentRound)
            {
                TournamentLogic.AlertUsersInNewRounds(model);
            }
        }

        /// <summary>
        /// When a new round is fully created, alert users.
        /// </summary>
        /// <param name="model">Tournament to update users in.</param>
        private static void AlertUsersInNewRounds(this TournamentModel model)
        {
            int currentRoundNumber = model.CheckCurrentRound();
            List<MatchupModel> currentRound = model.Rounds.Where(x => x.First().MatchupRound == currentRoundNumber).First();

            foreach (MatchupModel m in currentRound)
            {
                foreach (MatchupEntryModel me in m.Entries)
                {
                    foreach (PersonModel person in me.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(person, me.TeamCompeting.TeamName, m.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }

        /// <summary>
        /// Alerts person of the new round.
        /// </summary>
        /// <param name="person">Person to alert.</param>
        /// <param name="teamName">Team they're on.</param>
        /// <param name="matchupEntryModel">New Matchup to be played.</param>
        private static void AlertPersonToNewRound(PersonModel person, string teamName, MatchupEntryModel matchupEntryModel)
        {
            if (person.EmailAddress.Length == 0)
            {
                return;
            }

            string to = "";
            string subject = "";

            StringBuilder sb = new StringBuilder();

            if (matchupEntryModel != null)
            {
                subject = $"You have a new matchup with { matchupEntryModel.TeamCompeting.TeamName }";
                sb.AppendLine("<h1>You have a new matchup!</h1>");
                sb.Append("<strong>Competitor: </strong>");
                sb.Append(matchupEntryModel.TeamCompeting.TeamName);
                sb.Append("");
                sb.Append("");
                sb.AppendLine(", May the best team win!");
                sb.AppendLine("~ Tournament Tracker / SM");
            }
            else
            {
                subject = "You have a bye week this round";
                sb.Append("Enjoy your round off.");
                sb.AppendLine("~ Tournament Tracker / SM");
            }

            to = person.EmailAddress;

            Email.SendEmail(to, subject, sb.ToString());
        }

        /// <summary>
        /// Determines the round.
        /// </summary>
        /// <param name="model">Tournament to check for rounds.</param>
        /// <returns>Round number.</returns>
        private static int CheckCurrentRound(this TournamentModel model)
        {
            int output = 1;

            foreach (List<MatchupModel> round in model.Rounds)
            {
                if (round.All(x => x.Winner != null))
                {
                    output += 1;
                }
                else
                {
                    return output;
                }
            }


            // If else condition in not hit, the tournament is complete
            TournamentLogic.CompleteTournament(model);

            return output - 1;
        }

        /// <summary>
        /// Completes the tournament.
        /// </summary>
        /// <param name="model">Tournament to complete.</param>
        private static void CompleteTournament(TournamentModel model)
        {
            GlobalConfig.Connection.CompleteTournament(model);
            TeamModel winner = model.Rounds.Last().First().Winner;
            TeamModel runnerUp = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winner).First().TeamCompeting;

            decimal winnerPrize = 0;
            decimal runnerUpPrize = 0;

            if (model.Prizes.Count > 0)
            {
                decimal totalPrizeAmount = model.EnteredTeams.Count * model.EntryFee;

                PrizeModel firstPlace = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
                PrizeModel secondPlace = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

                if (firstPlace != null)
                {
                    winnerPrize = firstPlace.DeterminePrizePayOut(totalPrizeAmount);
                }

                if (secondPlace != null)
                {
                    runnerUpPrize = secondPlace.DeterminePrizePayOut(totalPrizeAmount);
                }
            }

            // Send email to all tournament 
            string subject = "";

            StringBuilder sb = new StringBuilder();

            subject = $"{model.TournamentName} has completed. {winner.TeamName} has won!";

            sb.AppendLine("<h1>WE HAVE A WINNER!</h1>");
            sb.AppendLine("<p>Congratulations to our winner on a great tournament.</p>");
            sb.AppendLine("<br />");

            if (winnerPrize > 0 )
            {
                sb.AppendLine($"<p>{winner.TeamName} will recieve ${winnerPrize}</p>");
            }

            if ( runnerUpPrize > 0)
            {
                sb.AppendLine($"<p>{runnerUp.TeamName} will recieve ${runnerUpPrize}</p>");
            }

            sb.AppendLine(", Thank you for competing!");
            sb.AppendLine("~ Tournament Tracker / SM");

            List<string> bcc = new List<string>();

            foreach (TeamModel t in model.EnteredTeams)
            {
                foreach (PersonModel p in t.TeamMembers)
                {
                    if (p.EmailAddress.Length > 0)
                    {
                        bcc.Add(p.EmailAddress);
                    }
                }
            }

            Email.SendEmail(new List<string>(), bcc, subject, sb.ToString());
        }


        /// <summary>
        /// Determines the payout for the prizes.
        /// </summary>
        /// <param name="prize">Prize to calcualate.</param>
        /// <param name="totalIncome">TOtal income of the tournament.</param>
        /// <returns>Prize amounts.</returns>
        private static decimal DeterminePrizePayOut(this PrizeModel prize, decimal totalIncome)
        {
            decimal output = 0;

            if (prize.PrizeAmount > 0)
            {
                output = prize.PrizeAmount;
            }
            else
            {
                output = Decimal.Multiply(totalIncome, Convert.ToDecimal(prize.PrizePercentage / 100));
            }

            return output;
        }

        /// <summary>
        /// Find every matchup in every rounds and update winner and parent matchup.
        /// </summary>
        /// <param name="models">A list of matchups</param>
        /// <param name="tournament">The tournament to update.</param>
        private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
        {
            foreach (MatchupModel m in models)
            {
                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel rm in round)
                    {
                        foreach (MatchupEntryModel me in rm.Entries)
                        {
                            if (me.ParentMatchup != null)
                            {
                                if (me.ParentMatchup.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;
                                    GlobalConfig.Connection.UpdateMatchup(m);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Scores each matchup to determine winners.
        /// </summary>
        /// <param name="matchups">Matchups to score.</param>
        private static void ScoreMatchups(List<MatchupModel> matchups)
        {
            // Greater or lesser than scoring.
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

            foreach (MatchupModel m in matchups)
            {
                // Bye week handling.
                if (m.Entries.Count == 1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }
              
                // 0 means false and low score will win. Based on app.config settings.
                if (greaterWins == "0")
                {
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if (m.Entries[1].Score < m.Entries[0].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("No ties allowed. Please declare a winner.");
                    }

                }
                else
                {
                        if (m.Entries[0].Score > m.Entries[1].Score)
                        {
                            m.Winner = m.Entries[0].TeamCompeting;
                        }
                        else if (m.Entries[1].Score > m.Entries[0].Score)
                        {
                            m.Winner = m.Entries[1].TeamCompeting;
                        }
                        else
                        {
                            throw new Exception("No ties allowed. Please declare a winner.");
                        }
                } 
            }
        }

        /// <summary>
        /// Creates the rest of the rounds other than the first round.
        /// </summary>
        /// <param name="model">Tournament to create rounds for.</param>
        /// <param name="rounds">Number of rounds we have.</param>
        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            int currentRoundCreating = 2;
            List<MatchupModel> previousRound = model.Rounds[0];
            List<MatchupModel> currentRound = new List<MatchupModel>();
            MatchupModel currentMatchup = new MatchupModel();

            while (currentRoundCreating <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    if(currentMatchup.Entries.Count > 1)
                    {
                        currentMatchup.MatchupRound = currentRoundCreating;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new MatchupModel();
                    }
                }

                model.Rounds.Add(currentRound);
                previousRound = currentRound;
                currentRound = new List<MatchupModel>();
                currentRoundCreating += 1;
            }
        }

        /// <summary>
        /// Creates the first round and the matchups.
        /// </summary>
        /// <param name="numberOfByes">Number of bye rounds in the tournament.</param>
        /// <param name="model">A list of teams.</param>
        /// <returns>The first round of the tournament.</returns>
        private static List<MatchupModel> CreateFirstRound(int numberOfByes, List<TeamModel> model)
        {
            List<MatchupModel> output = new List<MatchupModel>();

            MatchupModel current = new MatchupModel();

            foreach (TeamModel team in model)
            {
                current.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                if (numberOfByes > 0 || current.Entries.Count > 1)
                {
                    current.MatchupRound = 1;
                    output.Add(current);
                    current = new MatchupModel();

                    if (numberOfByes > 0)
                    {
                        numberOfByes -= 1;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Finds the number of bye rounds in the tournament.
        /// </summary>
        /// <param name="rounds">Rounds in the tournament.</param>
        /// <param name="numberOfTeams">Number of teams in the tournament.</param>
        /// <returns>The number of byes.</returns>
        private static int FindNumberOfByes(int rounds, int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - numberOfTeams;

            return output;
        }

        /// <summary>
        /// Determines the number of rounds for the tournament.
        /// </summary>
        /// <param name="teamCount">Number of teams to determine rounds.</param>
        /// <returns>The number of rounds.</returns>
        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int value = 2;

            while (value < teamCount)
            {
                output += 1;
                value *= 2;
            }

            return output;
        }

        /// <summary>
        /// Randomizes a list of teams in a tournament.
        /// </summary>
        /// <param name="model">Tournament to use.</param>
        /// <returns>A random list of teams.</returns>
        private static List<TeamModel> RandomizeTeams(List<TeamModel> model)
        {
            // Randomizes the list.
            // model.OrderBy(a => Guid.NewGuid()).ToList().
            return model.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
