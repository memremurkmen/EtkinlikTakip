using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class,  new()
    {
        Context c = new Context();
        public void Delete(T t)
        {
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetByID(long id)
        {
            return c.Set<T>().Find(id);
        }
        public T GetByID(Guid id)
        {
            return c.Set<T>().Find(id);
        }

        public IList<T> GetListAll()
        {
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            c.Update(t);
            c.SaveChanges();
        }
    }
}
