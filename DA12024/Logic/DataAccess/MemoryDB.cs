using Logic.Models;

namespace Logic.DataAccess
{
    public class MemoryDB
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

    }
}
