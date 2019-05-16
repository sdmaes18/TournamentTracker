using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary;

namespace TrackerLib.Data.TextHelpers
{
    /// <summary>
    /// Used to get the path of the selected file.
    /// </summary>
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// Gets the path of the text file.
        /// </summary>
        /// <param name="fileName">File where files are located.</param>
        /// <returns>Path to selected file.</returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        /// <summary>
        /// Loads a list of files.
        /// </summary>
        /// <param name="file">File to load.</param>
        /// <returns>A list of files.</returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Takes in a list of strings that turn into a list of person models.
        /// </summary>
        /// <param name="lines">Lines to read.</param>
        /// <returns>A list of person model.</returns>
        public static List<PersonModel> ConvertToPersonModel(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string l in lines)
            {
                // Split on comma to seperate data.
                string[] cols = l.Split(',');

                // Creates a new person model.
                PersonModel person = new PersonModel();

                // Assigns the person model data to selected columns.
                person.Id = int.Parse(cols[0]);
                person.FirstName = cols[1];
                person.LastName = cols[2];
                person.EmailAddress = cols[3];
                person.CellphoneNumber = cols[4];
                output.Add(person);
            }

            return output;
        }

        /// <summary>
        /// Takes in a list of strings that are turned into a list of tournaments.
        /// </summary>
        /// <param name="lines">Lines to read.</param>
        /// <param name="fileName">File to use.</param>
        /// <param name="peopleFileName">File for the people.</param>
        /// <param name="prizesFileName">File to get prizes.</param>
        /// <returns>A list of tournaments.</returns>
        public static List<TournamentModel> ConvertToTournamentModel(this List<string> lines, string fileName, string peopleFileName, string prizesFileName)
        {
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teamModel = fileName.FullFilePath().LoadFile().ConvertToTeamModel(peopleFileName);
            List<PrizeModel> prizes = prizesFileName.FullFilePath().LoadFile().ConvertToPrizeModel();

            foreach (string l in lines)
            {
                string[] cols = l.Split(',');

                TournamentModel tm = new TournamentModel();

                tm.Id = int.Parse(cols[0]);
                tm.TournamentName = cols[1];
                tm.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|');

                foreach (string id in teamIds)
                {
                    tm.EnteredTeams.Add(teamModel.Where(x => x.Id == int.Parse(id)).First());
                }

                string[] prizeIds = cols[4].Split('|');

                foreach (string id in prizeIds)
                {
                    tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                }

                //// TODO - rounds information.

                output.Add(tm);
            }

            return output;
        }

        /// <summary>
        /// Takes in a list of strings that turn into a list of prize model.
        /// </summary>
        /// <param name="lines">Lines to read.</param>
        /// <returns>A list of prize model.</returns>
        public static List<PrizeModel> ConvertToPrizeModel(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string l in lines)
            {
                // Splits the data by comma.
                string[] cols = l.Split(',');

                // Creates a new prize model.
                PrizeModel prize = new PrizeModel();

                // Assigning a selected column to prize data.
                prize.Id = int.Parse(cols[0]);
                prize.PlaceNumber = int.Parse(cols[1]);
                prize.PlaceName = cols[2];
                prize.PrizeAmount = decimal.Parse(cols[3]);
                prize.PrizePercentage = double.Parse(cols[4]);
                output.Add(prize);
            }

            return output;
        }

        /// <summary>
        /// Takes in a list of strings that turn into a lsit of matchup entry model.
        /// </summary>
        /// <param name="lines">String of model.</param>
        /// <returns>A list of matchup entry model.</returns>
        public static List<MatchupEntryModel> ConvertToMatchupEntryModel(this List<string> lines)
        {
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();

            foreach (string l in lines)
            {
                // Split on comma to seperate data.
                string[] cols = l.Split(',');

                // Creates a new person model.
                MatchupEntryModel entry = new MatchupEntryModel();

                // Assigns the person model data to selected columns.
                entry.Id = int.Parse(cols[0]);
                entry.TeamCompeting = LookUpTeamById(int.Parse(cols[1]));
                entry.Score = double.Parse(cols[2]);

                int parentId = 0;
                if (int.TryParse(cols[3], out parentId))
                {
                    entry.ParentMatchup = LookUpMatchUpById(parentId);
                }
                else
                {
                    entry.ParentMatchup = null;
                }
               
                output.Add(entry);
            }

            return output;
        }

        /// <summary>
        /// Converts to a team model.
        /// </summary>
        /// <param name="lines">Lines of the model to save.</param>
        /// <param name="peopleFileName">File of the people.</param>
        /// <returns>A list of the team model.</returns>
        public static List<TeamModel> ConvertToTeamModel(this List<string> lines, string peopleFileName)
        {
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModel();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TeamModel t = new TeamModel();

                t.Id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }

                output.Add(t);
            }

            return output;
        }

        /// <summary>
        /// Saves the rounds of the tournament to a file.
        /// </summary>
        /// <param name="model">Model or tournament to use.</param>
        /// <param name="MatchUpFile">File for the matchups.</param>
        /// <param name="MatchUpEntryFile">File for the matchup entries.</param>
        public static void SaveRoundsToFile(this TournamentModel model, string MatchUpFile, string MatchUpEntryFile)
        {
            foreach(List<MatchupModel> round in model.Rounds)
            {
                foreach(MatchupModel matchup in round)
                {
                    matchup.SaveMatchupToFile(MatchUpFile, MatchUpEntryFile);

                   
                }
            }
        }

        /// <summary>
        /// Takes in a list of strings that turn into a list of matchup models.
        /// </summary>
        /// <param name="lines">Lines to read.</param>
        /// <returns>A list of person model.</returns>
        public static List<MatchupModel> ConvertToMatchupModel(this List<string> lines)
        {
            List<MatchupModel> output = new List<MatchupModel>();

            foreach (string l in lines)
            {
                // Split on comma to seperate data.
                string[] cols = l.Split(',');

                // Creates a new person model.
                MatchupModel match = new MatchupModel();

                // Assigns the person model data to selected columns.
                match.Id = int.Parse(cols[0]);
                match.Entries = ConvertStringToMatchupEntriesModel(cols[1]);
                match.Winner = LookUpTeamById(int.Parse(cols[2]));
                match.MatchupRound = int.Parse(cols[3]);

                output.Add(match);
            }

            return output;
        }

        /// <summary>
        /// Converts models to a list of matchups.
        /// </summary>
        /// <param name="input">String of matchups.</param>
        /// <returns>A list version of the given string.</returns>
        private static List<MatchupEntryModel> ConvertStringToMatchupEntriesModel(string input)
        {
            string[] ids = input.Split('|');

            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            List<MatchupEntryModel> entries = GlobalConfig.MatchUpEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();

            foreach (string id in ids)
            {
                output.Add(entries.Where(x => x.Id == int.Parse(id)).First());
            }

            return output;
        }

        /// <summary>
        /// Looks up matchup by id.
        /// </summary>
        /// <param name="id">Id to look for.</param>
        /// <returns>Matchup with the id.</returns>
        public static MatchupModel LookUpMatchUpById(int id)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchUpFile.FullFilePath().LoadFile().ConvertToMatchupModel();

            return matchups.Where(x => x.Id == id).First();
        }

        /// <summary>
        /// Looks up team by the id.
        /// </summary>
        /// <param name="id">id of the team.</param>
        /// <returns></returns>
        private static TeamModel LookUpTeamById(int id)
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModel(GlobalConfig.PeopleFile);

            return teams.Where(x => x.Id == id).First();

        }

        /// <summary>
        /// Saves matchup entries to a file.
        /// </summary>
        /// <param name="model">Tournament to save.</param>
        /// <param name="matchupEntryFileName">File Name.</param>
        public static void SaveEntryToFile(this MatchupEntryModel model, string matchupEntryFileName)
        {
            List<MatchupEntryModel> entries = GlobalConfig.MatchUpFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();

            int currentId = 1;

            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            entries.Add(model);

            List<string> lines = new List<string>();

            foreach (MatchupEntryModel entry in entries)
            {
                string parent = string.Empty;
                if (entry.ParentMatchup != null)
                {
                    parent = entry.ParentMatchup.Id.ToString();
                }
                lines.Add($"{ entry.Id },{ entry.TeamCompeting.Id },{ entry.Score },{ parent }");
            }

            File.WriteAllLines(GlobalConfig.MatchUpEntryFile.FullFilePath(), lines);
        }

        /// <summary>
        /// Saves matchup to a file.
        /// </summary>
        /// <param name="model">Tournament to save.</param>
        /// <param name="matchupFile">File to save matchups.</param>
        /// <param name="matchupEntryFileName">File to save matchup entries.</param>
        public static void SaveMatchupToFile(this MatchupModel model, string matchupFile, string matchupEntryFileName)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchUpFile.FullFilePath().LoadFile().ConvertToMatchupModel();

            int currentId = 1;

            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            foreach (MatchupEntryModel entry in model.Entries)
            {
                entry.SaveEntryToFile(matchupEntryFileName);
            }

            List<string> lines = new List<string>();

            foreach (MatchupModel m in matchups)
            {
                string winnerId = string.Empty;
                if (m.Winner != null)
                {
                    winnerId = m.Winner.Id.ToString();
                }
                else
                {
                    winnerId = null;
                }

                lines.Add($"{ m.Id },{ ConvertMatchUpEntryListToString(m.Entries) },{ winnerId },{ m.MatchupRound }");
            }

            File.WriteAllLines(GlobalConfig.MatchUpFile.FullFilePath(), lines);
        }

        /// <summary>
        /// Saves information to a person file.
        /// </summary>
        /// <param name="models">Model to save.</param>
        /// <param name="fileName">File to save it to.</param>
        public static void SaveToPersonFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add($"{ p.Id },{ p.FirstName },{ p.LastName },{ p.EmailAddress },{ p.CellphoneNumber }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Saves information to a prize file.
        /// </summary>
        /// <param name="models">Model to save.</param>
        /// <param name="fileName">File to save it to.</param>
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{ p.Id },{ p.PlaceNumber },{ p.PlaceName },{ p.PrizeAmount },{ p.PrizePercentage }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Saves information to a team file.
        /// </summary>
        /// <param name="models">Model of the team to save.</param>
        /// <param name="fileName">File to save it in.</param>
        public static void SaveToTeamsFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel t in models)
            {
                lines.Add($"{ t.Id },{ t.TeamName },{ ConvertPeopleListToString(t.TeamMembers) }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Saves tournament to file.
        /// </summary>
        /// <param name="models">Model to save.</param>
        /// <param name="fileName">File name to save to.</param>
        public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TournamentModel tm in models)
            {
                lines.Add($@"{ tm.Id },
                             { tm.TournamentName },
                             { tm.EntryFee },
                             { ConvertTeamListToString(tm.EnteredTeams) },
                             { ConvertPrizeListToString(tm.Prizes) },
                             { ConvertRoundsListToString(tm.Rounds) }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Converts tournament rounds to a string.
        /// </summary>
        /// <param name="rounds">Rounds in the tournament.</param>
        /// <returns>A list of rounds in string format.</returns>
        private static string ConvertRoundsListToString(List<List<MatchupModel>> rounds)
        {
            // String used to return all people ids.
            string output = default(string);

            if (rounds.Count == 0)
            {
                return string.Empty;
            }

            // Add person id to string with pipe seperator.
            foreach (List<MatchupModel> p in rounds)
            {
                output += $"{ ConvertMatchupListToString(p) }|";
            }

            // Removes final pipe |.
            output = output.Substring(0, output.Length - 1);

            // return string of id.
            return output;
        }

        /// <summary>
        /// Converts the matchup's in a tournament into a string format.
        /// </summary>
        /// <param name="matchup">Matchup's in the tournament.</param>
        /// <returns>A string of matchup's.</returns>
        private static string ConvertMatchupListToString(List<MatchupModel> matchup)
        {
            // String used to return all people ids.
            string output = default(string);

            if (matchup.Count == 0)
            {
                return string.Empty;
            }

            // Add person id to string with pipe seperator.
            foreach (MatchupModel m in matchup)
            {
                output += $"{ m.Id }^";
            }

            // Removes final pipe |.
            output = output.Substring(0, output.Length - 1);

            // return string of id.
            return output;
        }

        /// <summary>
        /// Converts tournament prizes into a string.
        /// </summary>
        /// <param name="prizes">Prizes in the tournament.</param>
        /// <returns>A string of prizes.</returns>
        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            // String used to return all people ids.
            string output = default(string);

            if (prizes.Count == 0)
            {
                return string.Empty;
            }

            // Add person id to string with pipe seperator.
            foreach (PrizeModel p in prizes)
            {
                output += $"{ p.Id }|";
            }

            // Removes final pipe |.
            output = output.Substring(0, output.Length - 1);

            // return string of id.
            return output;
        }

        /// <summary>
        /// Converts the matchup entries into a list of string that is pipe seperated.
        /// </summary>
        /// <param name="entries">List of entries.</param>
        /// <returns>String of entries.</returns>
        private static string ConvertMatchUpEntryListToString(List<MatchupEntryModel> entries)
        {
            // String used to return all people ids.
            string output = default(string);

            if (entries.Count == 0)
            {
                return string.Empty;
            }

            // Add person id to string with pipe seperator.
            foreach (MatchupEntryModel e in entries)
            {
                output += $"{ e.Id }|";
            }

            // Removes final pipe |.
            output = output.Substring(0, output.Length - 1);

            // return string of id.
            return output;
        }

        /// <summary>
        /// Converts the teams in a tournament into a string.
        /// </summary>
        /// <param name="teams">List of teams.</param>
        /// <returns>A string of teams.</returns>
        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            // String used to return all people ids.
            string output = default(string);

            if (teams.Count == 0)
            {
                return string.Empty;
            }

            // Add person id to string with pipe seperator.
            foreach (TeamModel t in teams)
            {
                output += $"{ t.Id }|";
            }

            // Removes final pipe |.
            output = output.Substring(0, output.Length - 1);

            // return string of id.
            return output;
        }

        /// <summary>
        /// Take list of people and return a string.
        /// </summary>
        /// <param name="people">List of people.</param>
        /// <returns>A string of people from the list.</returns>
        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            // String used to return all people ids.
            string output = default(string);

            if (people.Count == 0)
            {
                return string.Empty;
            }

            // Add person id to string with pipe seperator.
            foreach (PersonModel p in people)
            {
                output += $"{ p.Id }|";
            }

            // Removes final pipe |.
            output = output.Substring(0, output.Length - 1);

            // return string of id.
            return output;
        }
    }
}
