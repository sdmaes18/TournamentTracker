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
        /// <returns>A model of the new person.</returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellphoneNumber", model.CellphoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        /// TODO - make the CreatePrize method save to the database.
        /// <summary>
        /// Creates a prize model.
        /// </summary>
        /// <param name="model">The model to create.</param>
        /// <returns>The created model.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        /// <summary>
        /// Creates a new team.
        /// </summary>
        /// <param name="model">Model of the new team.</param>
        /// <returns>A new team model.</returns>
        public TeamModel CreateTeam(TeamModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                var p = new DynamicParameters();
                p.Add("@TeamName", model.TeamName);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                foreach (PersonModel member in model.TeamMembers)
                {
                    p = new DynamicParameters();
                    p.Add("@TeamId", model.Id);
                    p.Add("@PersonId", member.Id);
                    connection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
                }

                return model;
            }
        }

        /// <summary>
        /// Gets a list of all the people from the database.
        /// </summary>
        /// <returns>A list of people.</returns>
        public List<PersonModel> GetPerson_All()
        {
            // A list to hold all the people.
            List<PersonModel> output = null;

            // Connect to the tournament database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // Call stored procedure and get all the people in database and turn into a list.
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            // Return the list of people.
            return output;
        }

        public List<TeamModel> GetTeam_All()
        {
            // A list to hold all the people.
            List<TeamModel> output = null;

            // Connect to the tournament database.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(Db)))
            {
                // Call stored procedure and get all the people in database and turn into a list.
                output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

                foreach (TeamModel team in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@TeamId", team.Id);

                    team.TeamMembers = connection.Query<PersonModel>("spTeamMembers_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            // Return the list of people.
            return output;
        }
    }
}
