using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Final_Project__True_Coders_.Models
{
    public class Game
    {
        //name, platforms, if the game has been finished (if it even ends), even how long to beat (hours)

        public int ListNumber { get; set; } 
        public string? Name { get; set; }
        public int GenreID { get; set; }

        public string? Platforms { get; set; }
        public bool IfEnds { get; set; }
        public bool IfFinished { get; set; }
        public double HowLongToBeat { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}
