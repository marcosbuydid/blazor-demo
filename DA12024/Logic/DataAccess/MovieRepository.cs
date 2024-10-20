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
    public class MovieRepository : IRepository<Movie>
    {
        protected readonly AppDbContext _appDbContext;

        public MovieRepository(AppDbContext appDbContext)
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
                _appDbContext.Update(movie);
                _appDbContext.Entry<Movie>(movie).State = EntityState.Modified;
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
