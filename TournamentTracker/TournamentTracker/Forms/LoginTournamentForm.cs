using System;
using System.Security.Cryptography;
using System.Text;
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
            string hashValue = this.Sha1Hash(this.PasswordLbl.Text);

            MessageBox.Show(hashValue);

            //TournamentDashboardForm frm = new TournamentDashboardForm();
            //frm.Show();
        }

        /// <summary>
        /// Provides a hash of a given string.
        /// </summary>
        /// <param name="text">Text to hash.</param>
        /// <returns>Returns the hash of the given text.</returns>
        private string Sha1Hash(string text)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] re = sh.Hash;

            StringBuilder sb = new StringBuilder();

            foreach (byte b in re)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
