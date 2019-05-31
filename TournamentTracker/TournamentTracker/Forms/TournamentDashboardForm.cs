using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    /// <summary>
    /// The starting dashboard form.
    /// </summary>
    public partial class TournamentDashboardForm : Form
    {
        /// <summary>
        /// A list of tournaments.
        /// </summary>
        public List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();

        /// <summary>
        /// Initializes a new instance of the TournamentDashboardForm class.
        /// </summary>
        public TournamentDashboardForm()
        {
            this.InitializeComponent();
            this.WireUpLists();
        }

        private void WireUpLists()
        {
            this.LoadExisitingTournamentDropDown.DataSource = null;
            this.LoadExisitingTournamentDropDown.DataSource = this.tournaments;
            this.LoadExisitingTournamentDropDown.DisplayMember = "TournamentName";
        }

        /// <summary>
        /// Opens the create tournament form.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm frm = new CreateTournamentForm();
            frm.Show();
        }

        /// <summary>
        /// Loads the selected tournament.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void LoadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = this.LoadExisitingTournamentDropDown.SelectedItem as TournamentModel;
            TournamentViewForm frm = new TournamentViewForm(tm);

            frm.Show();
        }
    }
}
