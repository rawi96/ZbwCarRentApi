﻿using System.Collections.Generic;
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