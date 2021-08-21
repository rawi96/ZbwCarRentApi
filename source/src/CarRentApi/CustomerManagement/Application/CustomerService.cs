using System.Collections.Generic;
using CarRentApi.CustomerManagement.Infrastructure;

namespace CarRentApi.CustomerManagement.Application
{
    public class CustomerService
    {
        private readonly CustomerRepo _repository;

        public CustomerService(CustomerRepo repository)
        {
            _repository = repository;
        }

        public virtual List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual Customer GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual Customer Add(Customer entity)
        {
            return _repository.Add(entity);
        }

        public virtual void Delete(Customer entity)
        {
            _repository.Delete(entity);
        }

        public virtual Customer Update(Customer entity)
        {
            return _repository.Update(entity);
        }
    }
}
