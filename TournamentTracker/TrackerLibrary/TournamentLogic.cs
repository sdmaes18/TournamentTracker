using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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
        /// <param name="model"></param>
        public static void UpdateTournamentResults(TournamentModel model)
        {
            List<MatchupModel> toScore = new List<MatchupModel>();

            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel roundMatchup in round)
                {
                    if (roundMatchup.Winner == null &&  (roundMatchup.Entries.Any(x => x.Score != 0) || roundMatchup.Entries.Count == 1))
                    {
                        toScore.Add(roundMatchup);
                    }
                }
            }

            TournamentLogic.ScoreMatchups(toScore);

            TournamentLogic.AdvanceWinners(toScore);

        }

        private static void AdvanceWinners(List<MatchupModel> matchups)
        {
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
