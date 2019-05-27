using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// Tournament Model to be loaded.
        /// </summary>
        private TournamentModel tournament;

        /// <summary>
        /// A list representing the number of rounds for the tournament.
        /// </summary>
        private BindingList<int> rounds = new BindingList<int>();

        /// <summary>
        /// A list of matchups for the round(s) in the tournament.
        /// </summary>
        private BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        /// <summary>
        /// Initializes a new instance of the TournamentViewForm class.
        /// </summary>
        /// <param name="model">Tournament to load.</param>
        public TournamentViewForm(TournamentModel model)
        {
            this.InitializeComponent();
            this.tournament = model;

            this.WireUpLists();

            this.LoadFormData();
            this.LoadRounds();
        }

        /// <summary>
        /// Loads form data about the tournament.
        /// </summary>
        private void LoadFormData()
        {
            this.TournamentNamelbl.Text = this.tournament.TournamentName;
        }

        /// <summary>
        /// Applies data to the drop down and list box.
        /// </summary>
        private void WireUpLists()
        {
            this.RoundDropDowncbox.DataSource = this.rounds;
            this.Matchuplbox.DataSource = this.selectedMatchups;
            this.Matchuplbox.DisplayMember = "DisplayName";
        }

        /// <summary>
        /// Determines the number of rounds to display in dropdown.
        /// </summary>
        private void LoadRounds()
        {
            this.rounds.Clear();
            this.rounds.Add(1);
            int currentRound = 1;

            foreach (List<MatchupModel> matchup in this.tournament.Rounds)
            {
                if (matchup.First().MatchupRound > currentRound)
                {
                    currentRound = matchup.First().MatchupRound;
                    this.rounds.Add(currentRound);
                }
            }

            this.LoadMatchups(1);
        }

        /// <summary>
        /// Determines what matchups to display.
        /// </summary>
        /// <param name="round">Round to display matchups in.</param>
        private void LoadMatchups(int round)
        {
            foreach (List<MatchupModel> matchup in this.tournament.Rounds)
            {
                if (matchup.First().MatchupRound == round)
                {
                    this.selectedMatchups.Clear();
                    foreach (MatchupModel m in matchup)
                    {
                        if (m.Winner == null || !this.UnPlayOnlybox.Checked)
                        {
                            this.selectedMatchups.Add(m);
                        }
                    }
                }
            }

            if (this.selectedMatchups.Count > 0)
            {
                this.LoadMatchUp(this.selectedMatchups.First());
            }

            this.DisplayMatchupInfo();
        }

        /// <summary>
        /// Displays matchup information is visable on form.
        /// </summary>
        private void DisplayMatchupInfo()
        {
            bool isVisable = this.selectedMatchups.Count > 0;

            this.TeamOneName.Visible = isVisable;
            this.TeamOneScorelbl.Visible = isVisable;
            this.TeamOneScoreValuetbox.Visible = isVisable;

            this.TeamTwoNamelbl.Visible = isVisable;
            this.TeamTwoScorelbl.Visible = isVisable;
            this.TeamTwoScoreValuetbox.Visible = isVisable;

            this.Vslbl.Visible = isVisable;
            this.Scorebtn.Visible = isVisable;
        }

        /// <summary>
        /// Anytime the rounds change update the matchups for the round.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void RoundDropDowncbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadMatchups((int)this.RoundDropDowncbox.SelectedItem);
        }

        /// <summary>
        /// Anytime the matchups change in the listbox, display the selected matchup.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void Matchuplbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Matchuplbox.SelectedItem == null)
            {
                return;
            }

            this.LoadMatchUp((MatchupModel)this.Matchuplbox.SelectedItem);
        }

        /// <summary>
        /// Load the selected matchup and display data to form.
        /// </summary>
        /// <param name="m">Matchup to display.</param>
        private void LoadMatchUp(MatchupModel m)
        {
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        this.TeamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                        this.TeamOneScoreValuetbox.Text = m.Entries[0].Score.ToString();

                        this.TeamTwoNamelbl.Text = "<BYE>";
                        this.TeamTwoScoreValuetbox.Text = "0";
                    }
                    else
                    {
                        this.TeamOneName.Text = "Not yet set";
                        this.TeamOneScoreValuetbox.Text = "0";
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        this.TeamTwoNamelbl.Text = m.Entries[1].TeamCompeting.TeamName;
                        //this.TeamOneScoreValuetbox.Text = m.Entries[1].Score.ToString();
                        this.TeamTwoScoreValuetbox.Text = m.Entries[1].Score.ToString();

                    }
                    else
                    {
                        this.TeamTwoNamelbl.Text = "Not yet set";
                        this.TeamTwoScoreValuetbox.Text  = "0";
                    }
                }
            }
        }

        /// <summary>
        /// If checked shows only unplayed matchups and vis versa.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void UnPlayOnlybox_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadMatchups((int)this.RoundDropDowncbox.SelectedItem);
        }

        /// <summary>
        /// Determines if the data is valid on the form or not.
        /// </summary>
        /// <returns>True if values are valid / false is data is not valid.</returns>
        private string IsValidData()
        {
            string output = "";
            double teamOneScore = 0;
            double teamTwoScore = 0;
            bool ScoreOneValid = double.TryParse(this.TeamOneScoreValuetbox.Text, out teamOneScore);
            bool ScoreTwoValid = double.TryParse(this.TeamTwoScoreValuetbox.Text, out teamTwoScore);

            if (!ScoreOneValid)
            {
                output = "Score one is not a valid number.";
            }
            else if (!ScoreTwoValid)
            {
                output = "Score two is not a valid number.";
            }
            else if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = "You didn't enter a score for either team.";
            }
            else if (teamOneScore == teamTwoScore)
            {
                output = "We do not allow ties. Please declare a winner.";
            }

            return output;
        }

        /// <summary>
        /// Score the current matchup.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void Scorebtn_Click(object sender, EventArgs e)
        {
            string error = this.IsValidData();
            if (error.Length > 0)
            {
                MessageBox.Show($"Input error: { error }");
                return;
            }

            MatchupModel m = (MatchupModel)this.Matchuplbox.SelectedItem;

            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        bool ScoreValid = double.TryParse(this.TeamOneScoreValuetbox.Text, out teamOneScore);

                        if (ScoreValid)
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team one.");
                            return;
                        }
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        bool ScoreValid = double.TryParse(this.TeamTwoScoreValuetbox.Text, out teamTwoScore);

                        if (ScoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team two.");
                            return;
                        }

                    }
                  
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(this.tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Application Error: { ex.Message }");
                return;
            }          
            this.LoadMatchups((int)this.RoundDropDowncbox.SelectedItem);
        }
    }
}
