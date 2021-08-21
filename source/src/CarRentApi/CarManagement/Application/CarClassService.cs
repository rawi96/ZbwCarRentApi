using System.Collections.Generic;
using CarRentApi.CarManagement.Infrastructure;

namespace CarRentApi.CarManagement.Application
{
    public class CarClassService
    {
        private readonly CarClassRepo _repository;

        public CarClassService(CarClassRepo repository)
        {
            _repository = repository;
        }

        public virtual List<CarClass> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual CarClass GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual CarClass Add(CarClass entity)
        {
            return _repository.Add(entity);
        }

        public virtual void Delete(CarClass entity)
        {
            _repository.Delete(entity);
        }

        public virtual CarClass Update(CarClass entity)
        {
            return _repository.Update(entity);
        }
    }
}
