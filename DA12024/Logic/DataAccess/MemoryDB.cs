using Domain;
using Logic.Models;

namespace Logic.DataAccess
{
    public class MemoryDB
    {
        public List<Movie> Movies { get; set; }
        public List<User> Users { get; set; }
        public MemoryDB()
        {
            Movies = new List<Movie>();
            loadDefaultMovies();
            Users = new List<User>();
            loadDefaultAdminUser();
        }

        private void loadDefaultMovies()
        {
            Movies.Add(new Movie("Black Rain", "Ridley Scott", new DateTime(1989, 09, 22), 30000000));
            Movies.Add(new Movie("Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22), 25000000));
            Movies.Add(new Movie("Training Day", "Antoine Fuqua", new DateTime(2002, 01, 18), 10000000));
        }
        private void loadDefaultAdminUser()
        {
            Users.Add(new User("Marcos","Castro","marcos@email.com", "123456","Administrator"));
        }

    }
}
