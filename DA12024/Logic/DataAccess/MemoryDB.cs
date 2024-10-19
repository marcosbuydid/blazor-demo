using Domain;
using Logic.Interfaces;
using Logic.Models;
using System.Linq;

namespace Logic.DataAccess
{
    public class MemoryDB : IRepository<Movie>, IRepository<User>
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
            Movies.Add(new Movie(null, "Black Rain", "Ridley Scott", new DateTime(1989, 09, 22), 30000000));
            Movies.Add(new Movie(null, "Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22), 25000000));
            Movies.Add(new Movie(null, "Training Day", "Antoine Fuqua", new DateTime(2002, 01, 18), 10000000));
        }
        private void loadDefaultAdminUser()
        {
            Users.Add(new User(null,"Marcos", "Castro", "marcos@email.com", "123456", "Administrator"));
        }

        public IList<Movie> FindAll()
        {
            return Movies;
        }

        public Movie? Find(Func<Movie, bool> filter)
        {
            return Movies.Where(filter).FirstOrDefault();
        }

        public void Add(Movie movie)
        {
            Movies.Add(movie);
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

        IList<User> IRepository<User>.FindAll()
        {
            return Users;
        }
        public User? Find(Func<User, bool> filter)
        {
            return Users.Where(filter).FirstOrDefault();
        }

        public void Add(User user)
        {
            Users.Add(user);
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            Users.Remove(user);
        }
    }
}
