using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentApi.Common;
using AutoMapper;

namespace CarRentApi.CarManagement.Application
{
    public class CarClassService
    {
        private IRepoBase<CarClass> _repository;

        public CarClassService(IRepoBase<CarClass> repository)
        {
            _repository = repository;
        }

        public List<CarClass> GetAll()
        {
            return _repository.GetAll();

        }

        public CarClass GetById(int id)
        {
            return _repository.GetById(id);
        }

        public CarClass Add(CarClass entity)
        {
            return _repository.Add(entity);
        }

        public void Delete(CarClass entity)
        {
            _repository.Delete(entity);
        }

        public CarClass Update(CarClass entity)
        {
            return _repository.Update(entity);
        }
    }
}
