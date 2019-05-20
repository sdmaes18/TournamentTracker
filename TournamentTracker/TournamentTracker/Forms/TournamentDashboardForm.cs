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
    /// The starting dashboard form.
    /// </summary>
    public partial class TournamentDashboardForm : Form
    {
        public List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();

        /// <summary>
        /// Initializes a new instance of the TournamentDashboardForm class.
        /// </summary>
        public TournamentDashboardForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Creates a tournament.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {

        }
    }
}
