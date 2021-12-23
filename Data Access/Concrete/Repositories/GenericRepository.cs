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
            var addedEntity = context.Entry(type);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T type)
        {
            var deletedEntity = context.Entry(type);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                   ? _object.ToList()
                   : _object.Where(filter).ToList();
        }

        public void Update(T type)
        {
            var updatedEntity = context.Entry(type);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
