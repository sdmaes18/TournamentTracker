using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using TrackerLib;
using TrackerLibrary;
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
            // Hash Value of entered password
            string hashValue = GlobalConfig.Sha1Hash(this.PasswordLbl.Text);

            // Provided email from user.
            string email = this.EmailTextBox.Text;

            // Represents a person, the person who logged in.
            PersonModel people = new PersonModel();

            // Get the type of connection either database or textfile.
            IDataConnection text = GlobalConfig.Connection;

            // Gets a person from a database.
            people = GlobalConfig.Connection.GetSinglePerson(email);

            // If no person was found, alert user to register for application.
            if (people == null)
            {
                MessageBox.Show("We dont have a record of this users email. Please register for application.");
                return;
            }

            // Log the user into the application if passwords match.
            if (people.Password == hashValue)
            {
                TournamentDashboardForm frm = new TournamentDashboardForm();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Login error: Password was not correct, please try again.");
            }
        }
    }
}
