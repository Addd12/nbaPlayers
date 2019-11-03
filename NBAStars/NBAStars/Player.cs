using System;
using System.Collections.Generic;
using System.Text;

namespace NBAStars
{
    class Player
    {
        /*public string name;
        //public DateTime year;
        public int year;
        private string position;
        public double rating;

        public Player(string name, int year, string position, double rating)
        {
            this.name = name;
            this.year = year;
            this.position = position;
            this.rating = rating;
        }*/

        public string Name { get; set; }
        public int PlayerSince { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }

    }
}
