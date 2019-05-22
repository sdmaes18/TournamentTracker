using System.Collections.Generic;

namespace TrackerLibrary
{
    /// <summary>
    /// Describes the matchup.
    /// </summary>
    public class MatchupModel
    {
        /// <summary>
        /// Gets or sets the id of the model.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a list of entries for the tournament.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        /// <summary>
        /// Gets or sets the winner of the matchup.
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Gets or sets the winnerId. ID from database to identify winner.
        /// </summary>
        public int WinnerId { get; set; }

        /// <summary>
        /// Gets or sets the round of the matchup.
        /// </summary>
        public int MatchupRound { get; set; }

        /// <summary>
        /// Get the names of the teams in a specific round.
        /// </summary>
        public string DisplayName
        {
            get
            {
                string output = "";
                foreach (MatchupEntryModel me in this.Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. { me.TeamCompeting.TeamName }";
                        }
                    }
                    else
                    {
                        output = "Matchup not yet determined.";
                        break;
                    }
                }

                return output;
            }       
         }
    }
}
