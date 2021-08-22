using System.Collections.Generic;
using System.Linq;
using CarRentApi.Common;
using Microsoft.EntityFrameworkCore;

namespace CarRentApi.CarManagement.Infrastructure
{
    public class CarRepo : BaseRepo<Car>
    {

        public CarRepo(ContextFactory contextFactory) : base(contextFactory)
        {

        }

        public override List<Car> GetAll()
        {
            using (var context = _contextFactory.GetNewContext())
            {
                return context.Cars.Include(c => c.CarClass).ToList();
            }
        }

        public override Car GetById(int id)
        {
            using (var context = _contextFactory.GetNewContext())
            {
                return context.Cars.Include(c => c.CarClass).FirstOrDefault(c => c.Id == id);
            }
        }

        public override Car Add(Car obj)
        {
            using (var context = _contextFactory.GetNewContext())
            {
                var attach = context.Cars.Attach(obj);
                context.SaveChanges();
                return GetById(attach.Entity.Id);
            }
        }

        public override Car Update(Car obj)
        {
            using (var context = _contextFactory.GetNewContext())
            {
                var attach = context.Cars.Update(obj);
                context.SaveChanges();
                return GetById(attach.Entity.Id);
            }
        }
    }
}
