using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarRentApi.Common
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {

        public virtual List<T> GetAll()
        {
            using (var context = new Context())
            { 
                var table = context.Set<T>();
                return table.ToList();
            }
        }

        public virtual T GetById(int id)
        {
            using (var context = new Context())
            {
                var table = context.Set<T>();
                return table.Find(id);
            }
        }

        public virtual T Add(T obj)
        {
            using (var context = new Context())
            {
                var table = context.Set<T>();
                var attach = table.Attach(obj);
                context.SaveChanges();
                return attach.Entity;

            }
        }

        public virtual T Update(T obj)
        {
            using (var context = new Context())
            {
                var table = context.Set<T>();
                var attach = table.Update(obj);
                context.SaveChanges();
                return attach.Entity;
            }
        }

        public virtual void Delete(T obj)
        {
            using (var context = new Context())
            {
                var table = context.Set<T>();
                table.Remove(obj);
                context.SaveChanges();
            }
        }
    }
}
