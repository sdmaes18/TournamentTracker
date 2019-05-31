using System;
using System.Windows.Forms;
using TrackerLibrary;

namespace TournamentTracker
{
    public partial class RegisterTournamentForm : Form
    {
        public RegisterTournamentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tries to register a user and save them in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            PersonModel person = new PersonModel();

            person.FirstName = this.FirstNameTxtBox.ToString();
            person.LastName = this.LastNameTxtBox.ToString();
            person.EmailAddress = this.EmailTxtBox.ToString();
            person.CellphoneNumber = this.CellPhoneTxtBox.ToString();
            person.Password = GlobalConfig.Sha1Hash(this.PasswordTxtBox.ToString());

            GlobalConfig.Connection.CreatePerson(person);
        }
    }
}
