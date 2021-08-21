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

        public List<Car> GetAll()
        {
            return _repository.GetAll();
        }

        public Car GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Car Add(Car entity)
        {
            return _repository.Add(entity);
        }

        public void Delete(Car entity)
        {
            _repository.Delete(entity);
        }

        public Car Update(Car entity)
        {
            return _repository.Update(entity);
        }
    }
}
