﻿using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using TrackerLib;

namespace TrackerLibrary
{
    /// <summary>
    /// Global configuration for data connections.
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// File to load and write prize data.
        /// </summary>
        public const string PrizesFile = "PrizeModels.csv";

        /// <summary>
        /// File to load and write people data.
        /// </summary>
        public const string PeopleFile = "PersonModels.csv";

        /// <summary>
        /// File to load and write team data.
        /// </summary>
        public const string TeamFile = "TeamModels.csv";

        /// <summary>
        /// File to load and write tournament data.
        /// </summary>
        public const string TournamentFile = "TournamentModels.csv";

        /// <summary>
        /// File to load and write match up data.
        /// </summary>
        public const string MatchUpFile = "MatchupFileModels.csv";

        /// <summary>
        /// File to load and write match up entries data.
        /// </summary>
        public const string MatchUpEntryFile = "MatchUpEntriesModels.csv";

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

        /// <summary>
        /// Gets the key value from app.config.
        /// </summary>
        /// <param name="key">Key to get value for.</param>
        /// <returns>Value of the given key from app.config</returns>
        public static string AppKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Provides a hash of a given string.
        /// </summary>
        /// <param name="text">Text to hash.</param>
        /// <returns>Returns the hash of the given text.</returns>
        public static string Sha1Hash(string text)
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
