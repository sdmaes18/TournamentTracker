using System.Collections.Generic;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents the team.
    /// </summary>
    public class TeamModel
    {
        /// <summary>
        /// Gets or sets the id of the team.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a list of team members.
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

        /// <summary>
        /// Gets or sets the team name.
        /// </summary>
        public string TeamName { get; set; }
    }
}
