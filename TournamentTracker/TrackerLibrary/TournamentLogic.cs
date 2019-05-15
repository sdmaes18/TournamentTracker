﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TrackerLibrary
{
    /// <summary>
    /// Logic for creating a tournament.
    /// </summary>
    public static class TournamentLogic
    {
        // Order list of teams randomly.
        // Check if it's big enough - if not add in a bye.
        // Create the first round of matchups.
        // Create every round after that.

        /// <summary>
        /// Creates the rounds for the tournament. 
        /// </summary>
        /// <param name="model">Tournament to create rounds for.</param>
        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeams(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byeRounds = FindNumberOfByes(rounds, randomizedTeams.Count);
        }

        /// <summary>
        /// Creates the first round and the matchups.
        /// </summary>
        /// <param name="numberOfByes">Number of bye rounds in the tournament.</param>
        /// <param name="model">A list of teams.</param>
        /// <returns>The first round of the tournament.</returns>
        private static List<MatchupModel> CreateFirstRound(int numberOfByes, List<TeamModel> model)
        {
            List<MatchupModel> output = new List<MatchupModel>();

            MatchupModel current = new MatchupModel();

            foreach (TeamModel team in model)
            {
                current.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                if (numberOfByes > 0 || current.Entries.Count > 1)
                {
                    current.MatchupRound = 1;
                    output.Add(current);
                    current = new MatchupModel();

                    if (numberOfByes > 0)
                    {
                        numberOfByes -= 1;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Finds the number of bye rounds in the tournament.
        /// </summary>
        /// <param name="rounds">Rounds in the tournament.</param>
        /// <param name="numberOfTeams">Number of teams in the tournament.</param>
        /// <returns>The number of byes.</returns>
        private static int FindNumberOfByes(int rounds, int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - numberOfTeams;

            return output;
        }

        /// <summary>
        /// Determines the number of rounds for the tournament.
        /// </summary>
        /// <param name="teamCount">Number of teams to determine rounds.</param>
        /// <returns>The number of rounds.</returns>
        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int value = 2;

            while (value < teamCount)
            {
                output += 1;
                value *= 2;
            }

            return output;
        }

        /// <summary>
        /// Randomizes a list of teams in a tournament.
        /// </summary>
        /// <param name="model">Tournament to use.</param>
        /// <returns>A random list of teams.</returns>
        private static List<TeamModel> RandomizeTeams(List<TeamModel> model)
        {
            // Randomizes the list.
            // model.OrderBy(a => Guid.NewGuid()).ToList().
            return model.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
