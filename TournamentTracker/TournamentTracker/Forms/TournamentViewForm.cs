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
        /// Initializes a new instance of the TournamentViewForm class.
        /// </summary>
        public TournamentViewForm(TournamentModel model)
        {
            this.InitializeComponent();
            this.tournament = model;
        }
    }
}
