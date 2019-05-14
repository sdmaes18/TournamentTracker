using System.Collections.Generic;
using System.Configuration;
using TrackerLib;

namespace TrackerLibrary
{
    /// <summary>
    /// Global configuration for data connections.
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// Gets a connections to save (get) data.
        /// </summary>
        public static IDataConnection Connection { get; private set; }

        /// <summary>
        /// Initializes a list of connections.
        /// </summary>
        /// <param name="database">Type of connection we have to a database.</param>
        public static void InitializeConnections(DatabaseType database)
        {
            switch (database)
            {
                case DatabaseType.Sql:
                    SQLConnector sql = new SQLConnector();
                    Connection = sql;
                    break;
                case DatabaseType.TextFile:
                    TextConnector text = new TextConnector();
                    Connection = text;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets connection string to database.
        /// </summary>
        /// <param name="name">Name of the path to database.</param>
        /// <returns>The connection string.</returns>
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
