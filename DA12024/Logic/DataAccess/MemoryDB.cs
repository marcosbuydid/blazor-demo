using Logic.Models;

namespace Logic.DataAccess
{
    public class MemoryDB : IRepository<Movie>
    {
        public List<Movie> Movies { get; set; }
        public MemoryDB()
        {
            Movies = new List<Movie>();
            loadDefaultMovies();
        }

        private void loadDefaultMovies()
        {
            Movies.Add(new Movie("Black Rain", "Ridley Scott", new DateTime(1989, 09, 22)));
            Movies.Add(new Movie("Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22)));
            Movies.Add(new Movie("Training Day", "Antoine Fuqua", new DateTime(2002, 01, 18)));
        }

        public void Add(Movie movie)
        {
            Movies.Add(movie);
        }

        public IList<Movie> FindAll()
        {
            return Movies;
        }

        public void Update(Movie movieToUpdate)
        {
            var movieToUpdateIndex = Movies.IndexOf(Movies.Find(m => m.Title == movieToUpdate.Title));
            Movies[movieToUpdateIndex] = movieToUpdate;
        }

        public void Delete(Movie movie)
        {
            Movies.Remove(movie);
        }

        public Movie? Find(Func<Movie, bool> filter)
        {
            return Movies.Where(filter).FirstOrDefault();
        }

    }
}
