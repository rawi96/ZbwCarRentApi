using System.Collections.Generic;
using CarRentApi.ReservationManagement.Infrastructure;

namespace CarRentApi.ReservationManagement.Application
{
    public class ReservationService
    {
        private readonly ReservationRepo _repository;

        public ReservationService(ReservationRepo repository)
        {
            _repository = repository;
        }

        public virtual List<Reservation> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual Reservation GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual Reservation Add(Reservation entity)
        {
            return _repository.Add(entity);
        }

        public virtual void Delete(Reservation entity)
        {
            _repository.Delete(entity);
        }

        public virtual Reservation Update(Reservation entity)
        {
            return _repository.Update(entity);
        }
    }
}
