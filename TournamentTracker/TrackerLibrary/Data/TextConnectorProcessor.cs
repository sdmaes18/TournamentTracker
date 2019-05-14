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
