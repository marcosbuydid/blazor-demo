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
        List<MovieDTO> GetMovies();
        void AddMovie(MovieDTO movie);
        void DeleteMovie(String title);
        void UpdateMovie(MovieDTO movie);
        MovieDTO SearchMovieByTitle(String title);

    }
}
