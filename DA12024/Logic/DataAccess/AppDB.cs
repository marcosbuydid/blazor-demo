using Domain;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.DataAccess
{
    public class AppDB : IRepository<Movie>, IRepository<User> 
    {
        protected readonly AppDbContext _appDbContext;

        public AppDB(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Movie movie)
        {
            try
            {
                _appDbContext.Set<Movie>().Add(movie);
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Movie movie)
        {
            try
            {
                _appDbContext.Set<Movie>().Remove(movie);
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public Movie? Find(Func<Movie, bool> filter)
        {
            return _appDbContext.Set<Movie>().FirstOrDefault(filter);
        }

        public IList<Movie> FindAll()
        {
            return _appDbContext.Set<Movie>().AsQueryable<Movie>().ToList();
        }

        public void Update(Movie movie)
        {
            try
            {
                //_appDbContext.Update(movie);
                //_appDbContext.Entry<Movie>(movie).State = EntityState.Modified;
                //_appDbContext.SaveChanges();

                var movieToUpdate = _appDbContext.FindAsync<Movie>(movie.Title);
                _appDbContext.Entry(movieToUpdate).CurrentValues.SetValues(movie);
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public User? Find(Func<User, bool> filter)
        {
            return _appDbContext.Set<User>().FirstOrDefault(filter);
        }

        public void Add(User user)
        {
            try
            {
                _appDbContext.Set<User>().Add(user);
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        IList<User> IRepository<User>.FindAll()
        {
            return _appDbContext.Set<User>().AsQueryable<User>().ToList();
        }
    }
}
