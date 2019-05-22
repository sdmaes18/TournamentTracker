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
        /// A list of matchups to be displayed.
        /// </summary>
        public List<MatchupModel> matchups = new List<MatchupModel>();

        /// <summary>
        /// Initializes a new instance of the TournamentViewForm class.
        /// </summary>
        public TournamentViewForm(TournamentModel model)
        {
            this.InitializeComponent();
            this.tournament = model;

            this.LoadFormData();
            this.LoadRounds();
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
            this.rounds = new List<int>();

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

            this.WireUpRoundsLists();
        }

        /// <summary>
        /// Updates the drop down list box.
        /// </summary>
        private void WireUpRoundsLists()
        {
            this.RoundDropDowncbox.DataSource = null;
            this.RoundDropDowncbox.DataSource = this.rounds;
        }

        /// <summary>
        /// Updates the matchus list box.
        /// </summary>
        private void WireUpMatchUpssLists()
        {
            this.Matchuplbox.DataSource = null;
            this.Matchuplbox.DataSource = this.matchups;
            this.Matchuplbox.DisplayMember = "DisplayName";
        }

        /// <summary>
        /// Every time a round is changed in the dropdown, display matchups.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void RoundDropDowncbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadMatchupList();
        }

        /// <summary>
        /// Loads the matchups for the specified round.
        /// </summary>
        private void LoadMatchupList()
        {
            int round = (int)this.RoundDropDowncbox.SelectedItem;

            foreach (List<MatchupModel> item in this.tournament.Rounds)
            {
                if (item.First().MatchupRound == round)
                {
                    this.matchups = item;
                }
            }

            this.WireUpMatchUpssLists();
        }

        /// <summary>
        /// Gets the selected matchup and displays the data on the form.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void Matchuplbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadMatchup();
        }

        /// <summary>
        /// Loads the matchup on the form.
        /// </summary>
        private void LoadMatchup()
        {
            MatchupModel m = this.Matchuplbox.SelectedItem as MatchupModel;

            for (int i = 0; i < m.Entries.Count; i++ )
            {
                if ( i == 0 )
                {

                }
            }
        }
    }
}
