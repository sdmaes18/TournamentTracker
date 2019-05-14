using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TournamentTracker;
using TrackerLibrary;

namespace TrackerUI
{
    /// <summary>
    /// Create tournament form.
    /// </summary>
    public partial class CreateTournamentForm : Form, IPrizeRequest, ITeamRequest
    {
        /// <summary>
        /// A list of all the teams in the database.
        /// </summary>
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();

        /// <summary>
        /// A list of selected teams to participate in the tournament.
        /// </summary>
        List<TeamModel> selectedTeams = new List<TeamModel>();

        /// <summary>
        /// A list of prizes for the tournament.
        /// </summary>
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        /// <summary>
        /// Initializes a new instance of the CreateTournamentForm class.
        /// </summary>
        public CreateTournamentForm()
        {
            this.InitializeComponent();

            this.WireUpLists();
        }

        /// <summary>
        /// Initializes components on the form.
        /// </summary>
        private void WireUpLists()
        {
            this.SelectTeamDropDown.DataSource = null;
            this.SelectTeamDropDown.DataSource = this.availableTeams;
            this.SelectTeamDropDown.DisplayMember = "TeamName";

            this.TournamentTeamsListBox.DataSource = null;
            this.TournamentTeamsListBox.DataSource = this.selectedTeams;
            this.TournamentTeamsListBox.DisplayMember = "TeamName";

            this.PrizesListBox.DataSource = null;
            this.PrizesListBox.DataSource = this.selectedPrizes;
            this.PrizesListBox.DisplayMember = "PlaceName";
        }

        /// <summary>
        /// Adds a team to the tournament.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = this.SelectTeamDropDown.SelectedItem as TeamModel;

            if (team != null)
            {
                this.selectedTeams.Add(team);
                this.availableTeams.Remove(team);

                this.WireUpLists();
            }
        }

        /// <summary>
        /// Creates the prize based on the teams in the tournament.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();
        }

        /// <summary>
        /// Gets our prize.
        /// </summary>
        /// <param name="model">Prize Model we created.</param>
        public void PrizeComplete(PrizeModel model)
        {
            this.selectedPrizes.Add(model);
            this.WireUpLists();
        }

        /// <summary>
        /// Gets our created team.
        /// </summary>
        /// <param name="model">Model of the team.</param>
        public void TeamComplete(TeamModel model)
        {
            this.selectedTeams.Add(model);
            this.WireUpLists();
        }

        /// <summary>
        /// Creates a new team on link click.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void CreateNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }

        /// <summary>
        /// Removes a team from the tournament.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void RemoveSelectedTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = this.TournamentTeamsListBox.SelectedItem as TeamModel;

            if (team != null)
            {
                this.selectedTeams.Remove(team);
                this.availableTeams.Add(team);

                this.WireUpLists();
            }
        }

        private void RemoveSelectedPrizebtn_Click(object sender, EventArgs e)
        {
            PrizeModel prize = this.PrizesListBox.SelectedItem as PrizeModel;

            if (prize != null)
            {
                this.selectedPrizes.Remove(prize);

                this.WireUpLists();
            }
        }
    }
}
