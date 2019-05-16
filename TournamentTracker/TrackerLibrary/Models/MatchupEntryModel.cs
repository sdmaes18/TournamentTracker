namespace TrackerLibrary
{
    /// <summary>
    /// Used to keep track of the match up model.
    /// </summary>
    public class MatchupEntryModel
    {
        /// <summary>
        /// Gets or sets the id of the matchup.
        /// </summary>
         public int Id { get; set; }

        /// <summary>
        /// Gets or sets the team competing.
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Gets or sets the score of the matchup.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Gets or sets the parent matchup.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}
