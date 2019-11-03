using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace NBAStars
{
    class NBAStarsCSVGenerator
    {
        private double minimumRating;
        private int minimumExperience;
        readonly List<Player> players;

        public NBAStarsCSVGenerator(string filePath)
        {
            string text = File.ReadAllText(filePath);
            players = JsonConvert.DeserializeObject<List<Player>>(text);
        }
                                                                                                                                                                                                                                                                                 
        public void SetMinimumRating(double rating)
        {
            minimumRating = rating;
        }

        public void SetMinimumYearsOfExperience(int years)
        {
            minimumExperience = years;
        }

        public void GenerateCSV(string csvFilePath)
        {
            List<Player> filteredPlayers = new List<Player>();
            foreach(var player in players)
            {
                int yearsOfExperience = DateTime.Now.Year - player.PlayerSince;

                if(yearsOfExperience > minimumExperience && player.Rating > minimumRating)
                {
                    filteredPlayers.Add(player);
                }
            }
            List<Player> sortedPlayers = filteredPlayers.OrderByDescending(r => r.Rating).ThenBy(n => n.Name).ToList();
            //filteredPlayers.Sort((x, y)=> x.Rating.CompareTo(y.Rating));

            StringBuilder stringBuilder = new StringBuilder();

            var header = string.Format("{0}, {1}", "Name", "Rating");
            stringBuilder.AppendLine(header);

            foreach (var nbaPlayer in sortedPlayers)
            {
                string Line = string.Format("{0}, {1}", nbaPlayer.Name, nbaPlayer.Rating);
                stringBuilder.AppendLine(Line);
            }
            //filteredPlayers.Sort((x, y)=> x.Rating.CompareTo(y.Rating));

            /*do
            {
                File.WriteAllText(csvFilePath, stringBuilder.ToString());
                if (!File.Exists(csvFilePath))
                {
                    Console.WriteLine("The path is not correct.");
                }

            } while (!File.Exists(csvFilePath));*/

            try
            {
                File.WriteAllText(csvFilePath, stringBuilder.ToString());
                if (File.Exists(csvFilePath))
                {
                    Console.WriteLine("The file is saved.");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid path!");
            }
        }
    }
}
