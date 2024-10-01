using Domain;
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

        public void AddMovie(MovieDTO movie)
        {
            ValidateMovieTitle(movie.Title);

            _memoryDB.Movies.Add(movie.ToEntity());
        }

        public void DeleteMovie(String title)
        {
            Movie movie = GetMovie(title);
            _memoryDB.Movies.Remove(movie);
        }

        public List<MovieDTO> GetMovies()
        {
            List<MovieDTO> moviesDTO = new List<MovieDTO>();

            foreach (var movie in _memoryDB.Movies)
            {
                moviesDTO.Add(MovieDTO.FromEntity(movie));
            }
            return moviesDTO;
        }

        public MovieDTO SearchMovieByTitle(String title)
        {
            Movie movie = _memoryDB.Movies.FirstOrDefault(movie => movie.Title == title);
            if (movie == null)
            {
                throw new ArgumentException("Cannot find movie with this title");
            }
            return MovieDTO.FromEntity(movie);
        }

        public void UpdateMovie(MovieDTO movieToUpdate)
        {
            var movieToUpdateIndex = _memoryDB.Movies.IndexOf(_memoryDB.Movies.Find(m => m.Title == movieToUpdate.Title));

            if (String.IsNullOrEmpty(movieToUpdate.Director))
            {
                throw new ArgumentException("Movie director cannot be empty or null");
            }

            _memoryDB.Movies[movieToUpdateIndex] = movieToUpdate.ToEntity();
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

        private Movie GetMovie(string title)
        {
            Movie movie = _memoryDB.Movies.FirstOrDefault(movie => movie.Title == title);
            if (movie == null)
            {
                throw new ArgumentException("Cannot find movie with this title");
            }
            return movie;
        }
    }
}
