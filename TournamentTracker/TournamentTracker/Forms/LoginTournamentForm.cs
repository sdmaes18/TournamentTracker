using System;
using System.Windows.Forms;
using TrackerUI;

namespace TournamentTracker
{
    public partial class LoginTournamentForm : Form
    {
        public LoginTournamentForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Logs the user into the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            TournamentDashboardForm frm = new TournamentDashboardForm();
            frm.Show();
        }
    }
}
