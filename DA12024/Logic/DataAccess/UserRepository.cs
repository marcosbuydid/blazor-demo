using Domain;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DataAccess
{
    public class UserRepository : IRepository<User>
    {
        protected readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        IList<User> IRepository<User>.FindAll()
        {
            return _appDbContext.Set<User>().AsQueryable<User>().ToList();
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
    }
}
