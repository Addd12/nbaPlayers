using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NBAStars
{
    class Program
    {

        static void Main(string[] args)
        {
            /*Console.Write("Please enter the path of the file: "); //C:\Users\enead\OneDrive\Desktop\MentorMate\players.json
            string path = Console.ReadLine();

            try
            {
                path = File.ReadAllText(path);
            }
            catch (Exception)
            {
                Console.WriteLine("Path not found!");
            }*/
            string path;
            do
            {
                Console.Write("Please enter the path of the file: "); //C:\Users\enead\OneDrive\Desktop\MentorMate\players.json
                path = Console.ReadLine();

                if (!File.Exists(path))
                {
                    Console.WriteLine("The path is not correct.");
                }

            } while (!File.Exists(path));

            NBAStarsCSVGenerator generator = new NBAStarsCSVGenerator(path);
            
            Console.Write("Minimum years of playing to qualify: ");
            int years = int.Parse(Console.ReadLine());

            generator.SetMinimumYearsOfExperience(years);

            Console.Write("Minimum rating to qualify: ");
            double rating = double.Parse(Console.ReadLine());

            generator.SetMinimumRating(rating);

            Console.Write("Write a path to generate the CSV file: ");
            generator.GenerateCSV(Console.ReadLine());

            Console.ReadLine();
        }

        //private static readonly List<Player> players;

        /*public static void Deserialize(string filePath)
        {

            String text = File.ReadAllText(filePath);
            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(text);

            foreach (var player in players)
            {
                Console.WriteLine(player.Name);
            }

        }*/
        /*
        public static List<Player> MinRequirements(int years)
        {
            //Console.Write("Minimum years of playing to qualify: ");
            //int years = int.Parse(Console.ReadLine());

            DateTime dt = new DateTime();

            int yearsPlaying = players.PlayerSince - dt.Year;

            if(years > yearsPlaying)
            {

            }

            Console.WriteLine(yearsPlaying);
        }*/
    }
}
  