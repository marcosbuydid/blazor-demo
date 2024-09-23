using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IMovieLogic
    {
        List<Movie> GetMovies();
        void AddMovie(Movie movie);
        void DeleteMovie(String title);
        void UpdateMovie(Movie movie);
        Movie FindMovieByTitle(String title);

    }
}
