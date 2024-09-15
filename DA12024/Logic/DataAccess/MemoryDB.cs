using Logic.Domain;

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
            Movies.Add(new Movie(1, "Black Rain", "Ridley Scott", new DateTime(1989, 09, 22)));
            Movies.Add(new Movie(2, "Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22)));
            Movies.Add(new Movie(1, "Training Day", "Antoine Fuqua", new DateTime(2002, 01, 18)));
        }

    }
}
