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
        public List<TeamModel> AvailableTeams = GlobalConfig.Connection.GetTeam_All();

        /// <summary>
        /// A list of selected teams to participate in the tournament.
        /// </summary>
        public List<TeamModel> SelectedTeams = new List<TeamModel>();

        /// <summary>
        /// A list of prizes for the tournament.
        /// </summary>
        public List<PrizeModel> SelectedPrizes = new List<PrizeModel>();

        /// <summary>
        /// Initializes a new instance of the CreateTournamentForm class.
        /// </summary>
        public CreateTournamentForm()
        {
            this.InitializeComponent();

            this.WireUpLists();
        }
                
        /// <summary>
        /// Gets our prize and adds it to the selected prizes for the tournament.
        /// </summary>
        /// <param name="model">Prize Model we created.</param>
        public void PrizeComplete(PrizeModel model)
        {
            this.SelectedPrizes.Add(model);
            this.WireUpLists();
        }

        /// <summary>
        /// Gets our created team.
        /// </summary>
        /// <param name="model">Model of the team.</param>
        public void TeamComplete(TeamModel model)
        {
            this.SelectedTeams.Add(model);
            this.WireUpLists();
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
                this.SelectedTeams.Remove(team);
                this.AvailableTeams.Add(team);

                this.WireUpLists();
            }
        }

        /// <summary>
        /// Removes a prize from the tournament.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void RemoveSelectedPrizebtn_Click(object sender, EventArgs e)
        {
            PrizeModel prize = this.PrizesListBox.SelectedItem as PrizeModel;

            if (prize != null)
            {
                this.SelectedPrizes.Remove(prize);

                this.WireUpLists();
            }
        }

        /// <summary>
        /// Actually creates the tournament.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void CreateTournamentBtn_Click(object sender, EventArgs e)
        {
            // Validate data.
            decimal fee = 0;
            bool feeAccepted = decimal.TryParse(this.EntryFreeValue.Text, out fee);

            if (!feeAccepted)
            {
                MessageBox.Show("You need to enter a valid entry fee.", "Invalid Fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create tournament model.
            TournamentModel model = new TournamentModel();

            model.TournamentName = this.TournamentNameValue.Text;
            model.EntryFee = fee;

            model.Prizes = this.SelectedPrizes;
            model.EnteredTeams = this.SelectedTeams;

            // Wire up matchups.
            TournamentLogic.CreateRounds(model);

            // Create tournament entries.
            GlobalConfig.Connection.CreateTournament(model);
        }

        /// <summary>
        /// Initializes components on the form.
        /// </summary>
        private void WireUpLists()
        {
            this.SelectTeamDropDown.DataSource = null;
            this.SelectTeamDropDown.DataSource = this.AvailableTeams;
            this.SelectTeamDropDown.DisplayMember = "TeamName";

            this.TournamentTeamsListBox.DataSource = null;
            this.TournamentTeamsListBox.DataSource = this.SelectedTeams;
            this.TournamentTeamsListBox.DisplayMember = "TeamName";

            this.PrizesListBox.DataSource = null;
            this.PrizesListBox.DataSource = this.SelectedPrizes;
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
                this.SelectedTeams.Add(team);
                this.AvailableTeams.Remove(team);

                this.WireUpLists();
            }
        }
    }
}
