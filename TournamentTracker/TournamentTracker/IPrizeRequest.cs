using TrackerLibrary;

namespace TournamentTracker
{
    public interface IPrizeRequest
    {
        void PrizeComplete(PrizeModel model);
    }
}
