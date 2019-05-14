using System;
using System.Collections.Generic;
using System.Linq;
using TrackerLib.Data.TextHelpers;

namespace TrackerLibrary
{
    /// <summary>
    /// Connects to a text file.
    /// </summary>
    public class TextConnector : IDataConnection
    {
        /// <summary>
        /// File to load and write prize data.
        /// </summary>
        private const string PrizesFile = "PrizeModels.csv";

        /// <summary>
        /// File to load and write people data.
        /// </summary>
        private const string PeopleFile = "PersonModels.csv";

        /// <summary>
        /// File to load and write team data.
        /// </summary>
        private const string TeamFile = "TeamModels.csv";

        /// <summary>
        /// File to load and write tournament data.
        /// </summary>
        private const string TournamentFile = "TournamentModels.csv";

        /// <summary>
        /// Creates a person.
        /// </summary>
        /// <param name="model">Model of the person to create.</param>
        /// <returns>A model of the new person.</returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            // Load text file.
            // Convert text to a list of prize model.
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();

            // If we have no data in prizes the starting id is 1.
            int currentId = 1;

            // adds a new id if we already have data in file.
            if (people.Count > 0)
            {
                currentId = currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            // Add a new record with new Id.
            people.Add(model);

            // Convert the prizes to a list of string.
            // Save a list of string to a textfile.
            people.SaveToPersonFile(PeopleFile);

            return model;
        }

        /// TODO - make the CreatePrize method save to the text file.
        /// <summary>
        /// Creates a prize model.
        /// </summary>
        /// <param name="model">The model to create.</param>
        /// <returns>The created model.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load text file.
            // Convert text to a list of prize model.
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            // If we have no data in prizes the starting id is 1.
            int currentId = 1;

            // adds a new id if we already have data in file.
            if (prizes.Count > 0)
            {
                currentId = currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            // Add a new record with new Id.
            prizes.Add(model);

            // Convert the prizes to a list of string.
            // Save a list of string to a textfile.
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        /// <summary>
        /// Creates a team.
        /// </summary>
        /// <param name="model">Model to represent the team.</param>
        /// <returns>A new team that was created.</returns>
        public TeamModel CreateTeam(TeamModel model)
        {
            // Loads the teams in the file.
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModel(PeopleFile);

            // If we have no data in prizes the starting id is 1.
            int currentId = 1;

            // adds a new id if we already have data in file.
            if (teams.Count > 0)
            {
                currentId = currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            // New teams id.
            model.Id = currentId;

            // Adding model to list.
            teams.Add(model);

            teams.SaveToTeamsFile(TeamFile);

            return model;
        }

        /// <summary>
        /// Creates a tournament.
        /// </summary>
        /// <param name="model">Model of the tournament.</param>
        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournament = TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModel(TeamFile, PeopleFile, PrizesFile);

            // If we have no data in prizes the starting id is 1.
            int currentId = 1;

            // adds a new id if we already have data in file.
            if (tournament.Count > 0)
            {
                currentId = currentId = tournament.OrderByDescending(x => x.Id).First().Id + 1;
            }

            // New teams id.
            model.Id = currentId;

            tournament.Add(model);

            tournament.SaveToTournamentFile(TournamentFile);
        }

        /// <summary>
        /// Gets a list of all people.
        /// </summary>
        /// <returns>Returns a list of people from database.</returns>
        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }

        /// <summary>
        /// Gets all teams from the text file.
        /// </summary>
        /// <returns>A list of the teams.</returns>
        public List<TeamModel> GetTeam_All()
        {
            return TeamFile.FullFilePath().LoadFile().ConvertToTeamModel(PeopleFile);
        }
    }
}
