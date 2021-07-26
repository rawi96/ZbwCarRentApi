using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarRentApi.Common
{
    public class RepoBase<T> : IRepoBase<T> where T : class
    {

        public List<T> GetAll()
        {
            using (var context = new Context())
            { 
                var table = context.Set<T>();
                return table.ToList();
            }
        }
        
        public T GetById(object id)
        {
            using (var context = new Context())
            {
                var table = context.Set<T>();
                return table.Find(id);
            }
        }
        
        public T Add(T obj)
        {
            using (var context = new Context())
            {
                var table = context.Set<T>();
                var attach = table.Attach(obj);
                context.SaveChanges();
                return attach.Entity;

            }
        }
        
        public T Update(T obj)
        {
            using (var context = new Context())
            {
                var table = context.Set<T>();
                var attach = table.Attach(obj);
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
                return attach.Entity;
            }
        }
        
        public void Delete(T obj)
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
