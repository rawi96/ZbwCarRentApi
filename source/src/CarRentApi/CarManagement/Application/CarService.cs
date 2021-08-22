using System.Collections.Generic;
using CarRentApi.CarManagement.Infrastructure;

namespace CarRentApi.CarManagement.Application
{
    public class CarService
    {
        private readonly CarRepo _repository;

        public CarService(CarRepo repository)
        {
            _repository = repository;
        }

        public virtual List<Car> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual Car GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual Car Add(Car entity)
        {
            return _repository.Add(entity);
        }

        public virtual void Delete(Car entity)
        {
            _repository.Delete(entity);
        }

        public virtual Car Update(Car entity)
        {
            return _repository.Update(entity);
        }
    }
}
