using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary;

namespace TournamentTracker
{
    /// <summary>
    /// Used to create a team when we open a new form.
    /// </summary>
    public interface ITeamRequest
    {
        /// <summary>
        /// Creates the team.
        /// </summary>
        /// <param name="model">Model of the team.</param>
        void TeamComplete(TeamModel model);
    }
}
