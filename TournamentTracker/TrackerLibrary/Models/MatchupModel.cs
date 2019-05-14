﻿using System.Collections.Generic;

namespace TrackerLibrary
{
    /// <summary>
    /// Describes the matchup.
    /// </summary>
    public class MatchupModel
    {
        /// <summary>
        /// Gets or sets a list of entries for the tournament.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        /// <summary>
        /// Gets or sets the winner of the matchup.
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Gets or sets the round of the matchup.
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
