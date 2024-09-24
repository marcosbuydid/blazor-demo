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
        private readonly IRepository<Movie> _moviesRepository;

        public MovieLogic(IRepository<Movie> moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public void AddMovie(Movie movie)
        {
            ValidateMovieTitle(movie.Title);

            _moviesRepository.Add(movie);
        }

        public void DeleteMovie(String title)
        {
            Movie movie = SearchMovieByTitle(title);
            _moviesRepository.Delete(movie);
        }

        public List<Movie> GetMovies()
        {
            return _moviesRepository.FindAll().ToList();
        }

        public Movie SearchMovieByTitle(String title)
        {
            Movie movie = _moviesRepository.Find(movie => movie.Title == title);
            if (movie == null)
            {
                throw new ArgumentException("Cannot find movie with this title");
            }
            return movie;
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            
            if (String.IsNullOrEmpty(movieToUpdate.Director))
            {
                throw new ArgumentException("Movie director cannot be empty or null");
            }

            _moviesRepository.Update(movieToUpdate);
        }

        private void ValidateMovieTitle(String title)
        {
            foreach (var movie in _moviesRepository.FindAll())
            {
                if(movie.Title == title)
                {
                    throw new ArgumentException("There`s a movie already defined with that title");
                }
            }
        }
    }
}
