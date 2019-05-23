using System;
using System.Collections.Generic;
using System.Linq;
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
        /// A list of rounds for the tournament.
        /// </summary>
        private List<int> rounds;

        /// <summary>
        /// A list of matchups for the tournament.
        /// </summary>
        private List<MatchupModel> matchups;

        /// <summary>
        /// Initializes a new instance of the TournamentViewForm class.
        /// </summary>
        public TournamentViewForm(TournamentModel model)
        {
            this.InitializeComponent();
            this.tournament = model;
            this.rounds = new List<int>();
            this.matchups = new List<MatchupModel>();

            this.WireUpFormData();
            this.LoadRound();
        }

        /// <summary>
        /// Loads tournament data onto form.
        /// </summary>
        private void WireUpFormData()
        {
            this.TournamentNamelbl.Text = this.tournament.TournamentName;
        }

        /// <summary>
        /// Loads list data such as rounds to the form.
        /// </summary>
        private void WireUpRoundsLists()
        {
            //this.RoundDropDowncbox.DataSource = null;
            this.RoundDropDowncbox.DataSource = this.rounds;
        }

        /// <summary>
        /// Wires up matchup list box with matches for tournament.
        /// </summary>
        private void WireUpMatchUpsList()
        {
            //this.Matchuplbox.DataSource = null;
            this.Matchuplbox.DataSource = this.matchups;
            this.Matchuplbox.DisplayMember = "DisplayName";
        }

        /// <summary>
        /// Loads the round(s) of the tournament.
        /// </summary>
        private void LoadRound()
        {
            this.rounds = new List<int>();

            this.rounds.Add(1);
            int currentRound = 1;

            foreach(List<MatchupModel> matchups in this.tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    this.rounds.Add(currentRound);
                }
            }

            this.WireUpRoundsLists();
        }

        /// <summary>
        /// Whenever an item is changed in the dropdown, update the matchup list box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void RoundDropDowncbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadMatchups();
        }

        /// <summary>
        /// Load the matchups for the tourament for a given round.
        /// </summary>
        private void LoadMatchups()
        {
            int round = (int)this.RoundDropDowncbox.SelectedItem;

            foreach (List<MatchupModel> matchups in this.tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    this.matchups = matchups;
                }
            }

            this.WireUpMatchUpsList();
        }

        /// <summary>
        /// Loads a selected matchup from the listbox dispaly.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void Matchuplbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadMatchup();
        }

        /// <summary>
        /// Load a single matchup to the form.
        /// </summary>
        private void LoadMatchup()
        {
            MatchupModel m = (MatchupModel)this.Matchuplbox.SelectedItem;

            for( int i = 0; i < m.Entries.Count; i++ )
            {
                if ( i == 0 )
                {
                    if ( m.Entries[0].TeamCompeting != null )
                    {
                        this.TeamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                        this.TeamOneScoreValuetbox.Text = m.Entries[0].Score.ToString();

                        this.TeamTwoNamelbl.Text = "<Bye>";
                        this.TeamTwoScoreValuetbox.Text = "0";
                    }
                    else
                    {
                        this.TeamOneName.Text = "Not yet set.";
                        this.TeamOneScoreValuetbox.Text = "0";
                    }
                }

                if ( i == 1 )
                {
                    if ( m.Entries[1].TeamCompeting != null )
                    {
                        this.TeamTwoNamelbl.Text = m.Entries[1].TeamCompeting.TeamName;
                        this.TeamTwoScoreValuetbox.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        this.TeamTwoNamelbl.Text = "Not yet set.";
                        this.TeamTwoScoreValuetbox.Text = "0";
                    }
                }
            }
        }
    }
}
