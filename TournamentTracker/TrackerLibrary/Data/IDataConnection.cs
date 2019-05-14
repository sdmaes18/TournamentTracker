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
        /// Creates a prize.
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
    }
}
