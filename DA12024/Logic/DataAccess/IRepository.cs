using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T Element);

        T? Find(Func<T, bool> filter);

        IList<T> FindAll();

        void Update(T entity);

        void Delete(T entity);
    }
}
