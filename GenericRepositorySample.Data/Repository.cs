using System.Collections.Generic;
using System.Linq;

namespace GenericRepositorySample.Data
{
    public class Repository<T> where T : class
    {
        private readonly Context context;

        public Repository(Context context)
        {
            this.context = context;
        }

        public IEnumerable<T> GetAll()
        {
            var list = context
                .Set<T>()
                .AsEnumerable();

            return list;
        }

        public int Count()
        {
            var count = context
                .Set<T>()
                .Count();

            return count;
        }

        public T GetById(object id)
        {
            var item = context
                .Find<T>(id);

            return item;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        protected IQueryable<T> Query()
        {
            var query = context
                .Set<T>()
                .AsQueryable();

            return query;
        }
    }
}
