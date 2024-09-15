using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Movie(int id, string title, string director, DateTime releaseYear)
        {
            Title = title;
            Director = director;
            ReleaseDate = releaseYear;
        }

        public override string ToString()
        {
            return ($"Title: {Title}, Director: {Director}, ReleaseYear: {ReleaseDate}");
        }

    }
}
