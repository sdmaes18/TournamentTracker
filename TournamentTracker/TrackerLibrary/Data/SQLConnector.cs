using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace TrackerLibrary
{
    /// <summary>
    /// Connects to SQL.
    /// </summary>
    public class SQLConnector : IDataConnection
    {
        /// <summary>
        /// Database to connect to.
        /// </summary>
        private const string Db = "Tournaments";

        /// <summary>
        /// Creates a person and records that data in the database.
        /// </summary>
        /// <param name="model">Person to create.</param>
        public void CreatePerson(PersonModel model)
        {
            // Connection to the database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // Using Dapper to add the person information to a variable.
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellphoneNumber", model.CellphoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Add the person to the databaes using a stored procedure.
                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                // Assinging the person modle to the id.
                model.Id = p.Get<int>("@id");
            }
        }

        /// <summary>
        /// Creates a prize model.
        /// </summary>
        /// <param name="model">The model to create.</param>
        public void CreatePrize(PrizeModel model)
        {
            // Connecting to the database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // Using Dapper to add the prize information to a variable.
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Execute a stored producer and store data in database.
                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");
            }
        }

        /// <summary>
        /// Creates a new team.
        /// </summary>
        /// <param name="model">Model of the new team.</param>
        public void CreateTeam(TeamModel model)
        {
            // Connecting to the database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // Using Dapper to add the team information to a variable.
                var p = new DynamicParameters();
                p.Add("@TeamName", model.TeamName);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Execute a stored procedure and save to database.
                // Saves the team data to database.
                connection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                // Execute a stored procedure and save to database.
                // Saves the teammember data to database for each time.
                foreach (PersonModel member in model.TeamMembers)
                {
                    p = new DynamicParameters();
                    p.Add("@TeamId", model.Id);
                    p.Add("@PersonId", member.Id);
                    connection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
                }

            }
        }

        /// <summary>
        /// Creates a new tournament.
        /// </summary>
        /// <param name="model">Model of the tournament.</param>
        public void CreateTournament(TournamentModel model)
        {
            // Connect to the database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // Save the tournament data.
                this.SaveTournament(connection, model);

                // Save the prize data for this tournament.
                this.SaveTournamentPrizes(connection, model);

                // Save the entries data for this tournament.
                this.SaveTournamentEntries(connection, model);

                // Save the rounds data for this tournament.
                this.SaveTournamentRounds(connection, model);

                // Used to update the tournament (mainly for bye weeks).
                TournamentLogic.UpdateTournamentResults(model);
            }
        }
        
        /// <summary>
        /// Gets a list of all the people from the database.
        /// </summary>
        /// <returns>A list of people.</returns>
        public List<PersonModel> GetPerson_All()
        {
            // new person object list.
            List<PersonModel> output = null;

            // Connect to database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // assing output to the stored procedure.
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            // return the list of people.
            return output;
        }

        /// <summary>
        /// Gets all the team from the database.
        /// </summary>
        /// <returns>A list of all the teams.</returns>
        public List<TeamModel> GetTeam_All()
        {
            // A team model list.
            List<TeamModel> output = null;

            // Connect to database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // Query stored procedure from database.
                output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

                
                foreach (TeamModel team in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@TeamId", team.Id);

                    team.TeamMembers = connection.Query<PersonModel>("spTeamMembers_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return output;
        }

        /// <summary>
        /// Saves the tournament to the database.
        /// </summary>
        /// <param name="connection">Database to save to.</param>
        /// <param name="model">Tournament to save.</param>
        private void SaveTournament(IDbConnection connection, TournamentModel model)
        {
            // Add tournament data to dapper Dynamicparameters.
            var p = new DynamicParameters();
            p.Add("@TournamentName", model.TournamentName);
            p.Add("@EntryFee", model.EntryFee);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            // store data in database by executing a stored procedure.
            connection.Execute("dbo.spTournaments_Insert", p, commandType: CommandType.StoredProcedure);

            model.Id = p.Get<int>("@id");
        }

        /// <summary>
        /// Saves the prizes to the database.
        /// </summary>
        /// <param name="connection">Database to save to.</param>
        /// <param name="model">Tournament to save prizes to.</param>
        private void SaveTournamentPrizes(IDbConnection connection, TournamentModel model)
        {
            // Loop through each prize in the tournament.
            foreach (PrizeModel pz in model.Prizes)
            {
                // Add prize info to DP varaible.
                var p = new DynamicParameters();
                p.Add("@TournamentId", model.Id);
                p.Add("@PrizeId", pz.Id);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Save prize info to database.
                connection.Execute("dbo.spTournamentPrizes_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Saves the teams to the database.
        /// </summary>
        /// <param name="connection">Database to save to.</param>
        /// <param name="model">Tournament to save entries to.</param>
        private void SaveTournamentEntries(IDbConnection connection, TournamentModel model)
        {
            // loop through each of the teams in the tournament.
            foreach (TeamModel tm in model.EnteredTeams)
            {
                // add each team to the new DP variable.
                var p = new DynamicParameters();
                p.Add("@TournamentId", model.Id);
                p.Add("@TeamId", tm.Id);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Execute stored procedure and save team to the database.
                connection.Execute("dbo.spTournamentEntries_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Saves the rounds of the tournament.
        /// </summary>
        /// <param name="connection">Connection to database.</param>
        /// <param name="model">Model of the tournament.</param>
        private void SaveTournamentRounds(IDbConnection connection, TournamentModel model)
        {
            // loop through each round in the tournament.
            foreach (List<MatchupModel> round in model.Rounds)
            {
                // loop through each matchup in the round.
                foreach (MatchupModel matchup in round)
                {
                    // add matchup data to DP variable.
                    var p = new DynamicParameters();
                    p.Add("@TournamentId", model.Id);
                    p.Add("@MatchupRound", matchup.MatchupRound);
                    p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    // save matchups to database.
                    connection.Execute("dbo.spMatchups_Insert", p, commandType: CommandType.StoredProcedure);

                    matchup.Id = p.Get<int>("@id");

                    // Loop through each matchup entry in the round matchup.
                    foreach (MatchupEntryModel entry in matchup.Entries)
                    {
                        // Add data to new DP variable.
                        p = new DynamicParameters();
                        p.Add("@MatchupId", matchup.Id);

                        if (entry.ParentMatchup == null)
                        {
                            p.Add("@ParentMatchupId", null);
                        }
                        else
                        {
                            p.Add("@ParentMatchupId", entry.ParentMatchup.Id);
                        }

                        if (entry.TeamCompeting == null)
                        {
                            p.Add("@TeamCompetingId", null);
                        }
                        else
                        {
                            p.Add("@TeamCompetingId", entry.TeamCompeting.Id);
                        }

                        p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        // Save the matchup entries to the database.
                        connection.Execute("dbo.spMatchupEntries_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a list of all the tournaments and the tournament info.
        /// </summary>
        /// <returns>A list of tournaments.</returns>
        public List<TournamentModel> GetTournament_All()
        {
            // a list of tournaments.
            List<TournamentModel> output = null;

            // Connect to the database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // assign output to the list of tournaments from the database.
                output = connection.Query<TournamentModel>("dbo.spTournaments_GetAll").ToList();
                var p = new DynamicParameters();

                // Loop through each tournament in output.
                foreach (TournamentModel t in output)
                {
                    // New DP variable to get tournament data from.
                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);

                    // Populate Prizes
                    t.Prizes = connection.Query<PrizeModel>("dbo.spPrizes_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);

                    // Populate Teams.
                    t.EnteredTeams = connection.Query<TeamModel>("dbo.spTeam_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    // Loop through each team in the tournaments entered teams.
                    foreach (TeamModel team in t.EnteredTeams)
                    {
                        p = new DynamicParameters();
                        p.Add("@TeamId", team.Id);

                        // assign the team members to the team.
                        team.TeamMembers = connection.Query<PersonModel>("spTeamMembers_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
                    }

                    // Populate Rounds.
                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);

                    // Get all the matchups for the tournament.
                    List<MatchupModel> matchups = connection.Query<MatchupModel>("dbo.spMatchups_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    // Loop through each matchup in matchups.
                    foreach (MatchupModel m in matchups)
                    {
                         // New DP variable to get matchup data from.
                        p = new DynamicParameters();
                        p.Add("@MatchupId", m.Id);

                        // Get all entries for the tournament.
                        m.Entries = connection.Query<MatchupEntryModel>("dbo.spMatchupEntries_GetByMatchup", p, commandType: CommandType.StoredProcedure).ToList();
                        
                        // A list of all the teams.
                        List<TeamModel> allTeams = this.GetTeam_All();

                        // assign winner.
                        if (m.WinnerId > 0)
                        {
                            m.Winner = allTeams.Where(x => x.Id == m.WinnerId).First();
                        }

                        foreach (var me in m.Entries)
                        {
                            if (me.TeamCompetingId > 0)
                            {
                                me.TeamCompeting = allTeams.Where(x => x.Id == me.TeamCompetingId).First();
                            }

                            if (me.ParentMatchupId > 0)
                            {
                                me.ParentMatchup = matchups.Where(x => x.Id == me.ParentMatchupId).First();
                            }
                        }
                    }

                    // a new list of matcup models.
                    List<MatchupModel> currentRow = new List<MatchupModel>();
                    
                    // indicates the current round.
                    int currentRound = 1;

                    // Loop through all the matchu models in matchups.
                    foreach (MatchupModel m in matchups)
                    {
                        // determine rounds.
                        if (m.MatchupRound > currentRound)
                        {
                            t.Rounds.Add(currentRow);
                            currentRow = new List<MatchupModel>();
                            currentRound += 1;
                        }

                        // Add matchup model to currentRow.
                        currentRow.Add(m);
                    }

                    // Add matchups to the rounds.
                    t.Rounds.Add(currentRow);
                }
            }

            // return the tournament.
            return output;
        }

        /// <summary>
        /// Updates a selected matchup and saves to the database.
        /// </summary>
        /// <param name="model">Model to update and save.</param>
        public void UpdateMatchup(MatchupModel model)
        {
            // Connect to database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // Declare dapper dynamic parameters varaible.
                var p = new DynamicParameters();
                
                // if the matchup has a winner
                //add the matchup id and winner id to dapper DP.
                if (model.Winner != null)
                {
                    p.Add("@id", model.Id);
                    p.Add("@WinnerId", model.WinnerId);

                    // Execute stored procedure to update the matchups.
                    connection.Execute("dbo.spMatchups_Update", p, commandType: CommandType.StoredProcedure);
                }

                // For each matchup entry in the matchup model
                // loop through to see if we have 2 teams.
                foreach (MatchupEntryModel me in model.Entries)
                {
                    // if we have 2 teams.
                    if (me.TeamCompeting != null)
                    {
                        // add id, team competitng id and score to DP variable.
                        p = new DynamicParameters();
                        p.Add("@id", me.Id);
                        p.Add("@TeamCompetingId", me.TeamCompeting.Id);
                        p.Add("@Score", me.Score);

                        // Execute stored procedure to update the matchup entries.
                        connection.Execute("dbo.spMatchupEntries_Update", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }

        /// <summary>
        /// Tournament to complete.
        /// </summary>
        /// <param name="model">Tournament to complete.</param>
        public void CompleteTournament(TournamentModel model)
        {
            // Conntect to the database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // Add the tournament id to dapper.
                var p = new DynamicParameters();
                p.Add("@id", model.Id);

                // Complete the tournament by reunning the stored procedure
                // Updates tournaemnt to finished.
                connection.Execute("dbo.spTournaments_Complete", p, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Used to get people from the database.
        /// </summary>
        /// <param name="email">Email to look up user.</param>
        /// <returns>A single person.</returns>
        public PersonModel GetSinglePerson(string email)
        {
            // holds a list of all people.
            List<PersonModel> output = null;

            // Connect to the database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // assign output to the stored procedure of getting all people.
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            // A new person model to return.
            PersonModel person = new PersonModel();

            // Loop through each person in output.
            foreach (PersonModel p in output)
            {
                // If the email address matches the email parameter assign person to p and return the person object.
                if (p.EmailAddress.Equals(email))
                {
                    person = p;
                    return person;
                }
            }

            // Return null if no person was found where the emails match.
            return null;
        }
    }
}
