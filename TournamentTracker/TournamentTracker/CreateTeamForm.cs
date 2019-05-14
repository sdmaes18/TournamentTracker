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
    /// Create team form.
    /// </summary>
    public partial class CreateTeamForm : Form
    {
        /// <summary>
        /// People who can be chosen to be on a team.
        /// </summary>
        private List<PersonModel> availableTeamMebmers = GlobalConfig.Connection.GetPerson_All();

        /// <summary>
        /// Allows you to select people for a team.
        /// </summary>
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        /// <summary>
        /// Initializes a new instance of the CreateTeamForm class.
        /// </summary>
        public CreateTeamForm()
        {
            this.InitializeComponent();

            //// this.CreateSampleData();

            this.WireUpLists();
        }

        /// <summary>
        /// Wires up the drop down list.
        /// </summary>
        private void WireUpLists()
        {
            this.SelectTeamMemberDropDown.DataSource = null;

            this.SelectTeamMemberDropDown.DataSource = this.availableTeamMebmers;
            this.SelectTeamMemberDropDown.DisplayMember = "FullName";

            this.TeamMembersListBox.DataSource = null;

            this.TeamMembersListBox.DataSource = this.selectedTeamMembers;
            this.TeamMembersListBox.DisplayMember = "FullName";
        }

        /// <summary>
        /// Creates a sample data for testing.
        /// </summary>
        private void CreateSampleData()
        {
            this.availableTeamMebmers.Add(new PersonModel { FirstName = "Steven", LastName = "Maes" });
            this.availableTeamMebmers.Add(new PersonModel { FirstName = "Jordan", LastName = "Maes" });

            this.selectedTeamMembers.Add(new PersonModel { FirstName = "Brad", LastName = "Maes" });
            this.selectedTeamMembers.Add(new PersonModel { FirstName = "Kate", LastName = "Maes" });
        }

        /// <summary>
        /// Creates a new member for the team.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void CreateMemberButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm())
            {
                // Creates a new person.
                PersonModel person = new PersonModel();

                // Set the new person values to user entered information.
                person.FirstName = this.FirstNameValue.Text;
                person.LastName = this.LastNameValue.Text;
                person.EmailAddress = this.EmailValue.Text;
                person.CellphoneNumber = this.CellPhoneValue.Text;

                // Connect to data connection. Which is either sql or textfile.
                person = GlobalConfig.Connection.CreatePerson(person);

                this.selectedTeamMembers.Add(person);

                this.WireUpLists();

                // Reset form values to empty.
                this.FirstNameValue.Text = string.Empty;
                this.LastNameValue.Text = string.Empty;
                this.EmailValue.Text = string.Empty;
                this.CellPhoneValue.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please fill in all the Fields");
            }
        }

        /// <summary>
        /// Validates the form.
        /// </summary>
        /// <returns>A true of false value if the form was valid or not.</returns>
        private bool ValidateForm()
        {
            // Checking for name validation.
            if (this.FirstNameValue.Text.Length == 0)
            {
                return false;
            }

            // Checks to see if theres a last name.
            if (this.LastNameValue.Text.Length == 0)
            {
                return false;
            }

            // Check to see if something was added to form.
            if (this.EmailValue.Text.Length == 0)
            {
                return false;
            }

            // Checks to see the cell phone value.
            if (this.CellPhoneValue.Text.Length == 0)
            {
                return false;
            }

            // Return true if the form is valid.
            return true;
        }

        /// <summary>
        /// Adds a team member to the team.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void AddTeamMemberButton_Click(object sender, EventArgs e)
        {
            // Gets the selected person.
            PersonModel p = this.SelectTeamMemberDropDown.SelectedItem as PersonModel;

            if (p != null)
            {
                this.availableTeamMebmers.Remove(p);
                this.selectedTeamMembers.Add(p);

                this.WireUpLists();
            }
        }

        /// <summary>
        /// Removes a selected team member from the list.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void DeleteSelectedMemberButton_Click(object sender, EventArgs e)
        {
            // Gets the selected person.
            PersonModel p = this.TeamMembersListBox.SelectedItem as PersonModel;

            if (p != null)
            {
                this.selectedTeamMembers.Remove(p);
                this.availableTeamMebmers.Add(p);

                this.WireUpLists();
            }
        }

        /// <summary>
        /// Creates the team of selected members.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void CreateTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = new TeamModel();

            team.TeamName = this.TeamNameValue.Text;
            team.TeamMembers = this.selectedTeamMembers;

            team = GlobalConfig.Connection.CreateTeam(team);

            // TODO - if we arn't closing form after creation, reset the form.
        }
    }
}
