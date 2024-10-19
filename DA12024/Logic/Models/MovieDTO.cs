using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class MovieDTO
    {
        [Key]
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Budget { get; set; }  

        public Movie ToEntity()
        {
            return new Movie(Id, Title, Director, ReleaseDate, Budget)
            {
                Id = Id,
                Title = Title,
                Director = Director,
                ReleaseDate = ReleaseDate,
                Budget = Budget
            };
        }

        public static MovieDTO FromEntity(Movie movie)
        {
            return new MovieDTO()
            {
                Title = movie.Title,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate,
            };
        }

    }
}
