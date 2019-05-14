using System;
using System.Windows.Forms;
using TrackerLib;

namespace TrackerUI
{
    /// <summary>
    /// Starting program for the main entry point of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the database connections. Have a database (SQL) or a text file like excel.
            TrackerLibrary.GlobalConfig.InitializeConnections(DatabaseType.Sql);

            Application.Run(new CreateTeamForm());
        }
    }
}
