using Data_Access.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public Context context = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }

        public void Add(T type)
        {
            throw new NotImplementedException();
        }

        public void Delete(T type)
        {
            throw new NotImplementedException();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(T type)
        {
            throw new NotImplementedException();
        }
    }
}
