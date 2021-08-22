using CarRentApi.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarRentApi.ReservationManagement.Infrastructure
{
    public class ReservationRepo : BaseRepo<Reservation>
    {

        public ReservationRepo(ContextFactory contextFactory) : base(contextFactory)
        {

        }

        public override List<Reservation> GetAll()
        {
            using (var context = _contextFactory.GetNewContext())
            {
                return context.Reservations
                    .Include(c => c.Car)
                    .ThenInclude(c => c.CarClass)
                    .Include(c => c.Customer)
                    .ToList();
            }
        }

        public override Reservation GetById(int id)
        {
            using (var context = _contextFactory.GetNewContext())
            {
                return context.Reservations
                    .Include(c => c.Car)
                    .ThenInclude(c => c.CarClass)
                    .Include(c => c.Customer)
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        public override Reservation Add(Reservation obj)
        {
            using (var context = _contextFactory.GetNewContext())
            {
                var attach = context.Reservations.Attach(obj);
                context.SaveChanges();
                return GetById(attach.Entity.Id);
            }
        }

        public override Reservation Update(Reservation obj)
        {
            using (var context = _contextFactory.GetNewContext())
            {
                var attach = context.Reservations.Update(obj);
                context.SaveChanges();
                return GetById(attach.Entity.Id);
            }
        }

    }
}
