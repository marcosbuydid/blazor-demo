using Logic.DataAccess;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MovieLogic : IMovieLogic
    {
        private readonly MemoryDB _MemoryDB;

        public MovieLogic(MemoryDB memoryDB)
        {
            _MemoryDB = memoryDB;
        }

        public void AddMovie(Movie movie)
        {
            if (String.IsNullOrEmpty(movie.Title))
            {
                throw new ArgumentException("Movie title cannot be empty or null");
            }
            if (String.IsNullOrEmpty(movie.Director))
            {
                throw new ArgumentException("Movie director cannot be empty or null");
            }

            ValidateMovieTitle(movie.Title);

            _MemoryDB.Movies.Add(movie);
        }

        public void DeleteMovie(string title)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMovies()
        {
            return _MemoryDB.Movies;
        }

        private void ValidateMovieTitle(String title)
        {
            foreach (var movie in _MemoryDB.Movies)
            {
                if(movie.Title == title)
                {
                    throw new ArgumentException("There`s a movie already defined with that title");
                }
            }
        }
    }
}
