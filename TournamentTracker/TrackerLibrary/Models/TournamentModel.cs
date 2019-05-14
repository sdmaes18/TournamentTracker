using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents a tournament.
    /// </summary>
    public class TournamentModel
    {
        /// <summary>
        /// Gets or sets the id for the tournament.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tournament name.
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// Gets or sets the tournament entry fee.
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Gets or sets the teams that are in the tournament.
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();

        /// <summary>
        /// Gets or sets the list of prizes in the tournament.
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

        /// <summary>
        /// Gets or sets a list of rounds in the tournament.
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();
    }
}
