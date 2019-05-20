using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Used to keep track of data connections.
    /// </summary>
    public interface IDataConnection
    {
        /// <summary>
        /// Creates a prize for the tournament.
        /// </summary>
        /// <param name="model">Model to use for the prize.</param>
        /// <returns>A created prize.</returns>
        PrizeModel CreatePrize(PrizeModel model);

        /// <summary>
        /// Creates a person.
        /// </summary>
        /// <param name="model">Person to create.</param>
        /// <returns>The created person.</returns>
        PersonModel CreatePerson(PersonModel model);

        /// <summary>
        /// Creates a team.
        /// </summary>
        /// <param name="model">Model to represent the team.</param>
        /// <returns>A newly created team.</returns>
        TeamModel CreateTeam(TeamModel model);

        /// <summary>
        /// Get a list of all persons.
        /// </summary>
        /// <returns>A list of people.</returns>
        List<PersonModel> GetPerson_All();

        /// <summary>
        /// Gets a list of all the teams in the database.
        /// </summary>
        /// <returns>A list of all the teams.</returns>
        List<TeamModel> GetTeam_All();

        /// <summary>
        /// Creates a tournament.
        /// </summary>
        /// <param name="model">Model for the tournament.</param>
        void CreateTournament(TournamentModel model);

        /// <summary>
        /// Gets all the tournaments in database.
        /// </summary>
        /// <returns>A list of tournaments we have.</returns>
        List<TournamentModel> GetTournament_All();
    }
}
