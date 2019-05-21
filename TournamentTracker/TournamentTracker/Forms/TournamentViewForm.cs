using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    /// <summary>
    /// The tournament view form.
    /// </summary>
    public partial class TournamentViewForm : Form
    {
        /// <summary>
        /// Represents the tourament to look at.
        /// </summary>
        private TournamentModel tournament;

        /// <summary>
        /// Used to keep round data for the tournament.
        /// </summary>
        public List<int> rounds = new List<int>();

        /// <summary>
        /// Initializes a new instance of the TournamentViewForm class.
        /// </summary>
        public TournamentViewForm(TournamentModel model)
        {
            this.InitializeComponent();
            this.tournament = model;

            this.LoadFormData();
        }

        /// <summary>
        /// Loads the tournament data.
        /// </summary>
        private void LoadFormData()
        {
            this.TournamentNamelbl.Text = this.tournament.TournamentName;
        }

        /// <summary>
        /// Depending on selected round. It loads the round data.
        /// </summary>
        private void LoadRounds()
        {
            this.rounds.Add(1);

            int currentRound = 1;

            foreach (List<MatchupModel> item in this.tournament.Rounds)
            {
                if (item.First().MatchupRound > currentRound)
                {
                    currentRound = item.First().MatchupRound;
                    this.rounds.Add(currentRound);
                }
            }
        }
    }
}
