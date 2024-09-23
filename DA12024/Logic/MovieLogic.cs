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
        private readonly MemoryDB _memoryDB;

        public MovieLogic(MemoryDB memoryDB)
        {
            _memoryDB = memoryDB;
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

            _memoryDB.Movies.Add(movie);
        }

        public void DeleteMovie(String title)
        {
            Movie movie = FindMovieByTitle(title);
            _memoryDB.Movies.Remove(movie);
        }

        public List<Movie> GetMovies()
        {
            return _memoryDB.Movies;
        }

        public Movie FindMovieByTitle(String title)
        {
            Movie movie = _memoryDB.Movies.FirstOrDefault(movie => movie.Title == title);
            if (movie == null)
            {
                throw new ArgumentException("Cannot find movie with this title");
            }
            return movie;
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            var movieToUpdateIndex = _memoryDB.Movies.IndexOf(_memoryDB.Movies.Find(m => m.Title == movieToUpdate.Title));

            if (String.IsNullOrEmpty(movieToUpdate.Director))
            {
                throw new ArgumentException("Movie director cannot be empty or null");
            }

            _memoryDB.Movies[movieToUpdateIndex] = movieToUpdate;
        }

        private void ValidateMovieTitle(String title)
        {
            foreach (var movie in _memoryDB.Movies)
            {
                if(movie.Title == title)
                {
                    throw new ArgumentException("There`s a movie already defined with that title");
                }
            }
        }
    }
}
