using Logic.DataAccess;
using Logic.Domain;
using Logic.Interfaces;
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

        public List<Movie> GetMovies()
        {
            return _MemoryDB.Movies;
        }
    }
}
