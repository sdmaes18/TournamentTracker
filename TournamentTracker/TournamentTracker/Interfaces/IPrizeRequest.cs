using TrackerLibrary;

namespace TournamentTracker
{
    /// <summary>
    /// Gets a prize when we open a new form from the tournament form.
    /// </summary>
    public interface IPrizeRequest
    {
        /// <summary>
        /// Creates a completed prize.
        /// </summary>
        /// <param name="model">Prize to be used.</param>
        void PrizeComplete(PrizeModel model);
    }
}
