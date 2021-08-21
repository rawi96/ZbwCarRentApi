using System.Collections.Generic;
using System.Linq;
using CarRentApi.Common;
using Microsoft.EntityFrameworkCore;

namespace CarRentApi.CarManagement.Infrastructure
{
    public class CarRepo : BaseRepo<Car>
    {
        public override List<Car> GetAll()
        {
            using (var context = new Context())
            {
                return context.Cars.Include(c => c.CarClass).ToList();
            }
        }

        public override Car GetById(int id)
        {
            using (var context = new Context())
            {
                return context.Cars.Include(c => c.CarClass).FirstOrDefault(c => c.Id == id);
            }
        }

        public override Car Add(Car obj)
        {
            using (var context = new Context())
            {
                var attach = context.Cars.Attach(obj);
                context.SaveChanges();
                return GetById(attach.Entity.Id);
            }
        }

        public override Car Update(Car obj)
        {
            using (var context = new Context())
            {
                var attach = context.Cars.Update(obj);
                context.SaveChanges();
                return GetById(attach.Entity.Id);
            }
        }
    }
}
