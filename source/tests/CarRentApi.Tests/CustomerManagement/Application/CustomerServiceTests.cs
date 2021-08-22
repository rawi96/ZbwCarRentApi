using CarRentApi.CustomerManagement;
using CarRentApi.CustomerManagement.Application;
using CarRentApi.CustomerManagement.Infrastructure;
using FakeItEasy;
using Xunit;

namespace CarRentApi.Tests
{
    public class CustomerServiceTests
    {

        [Fact]
        public void GetAll_Invokes_GetAll()
        {
            var repo = A.Fake<CustomerRepo>();
            var service = new CustomerService(repo);

            service.GetAll();

            A.CallTo(() => repo.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void GetById_Invokes_GetById()
        {
            var repo = A.Fake<CustomerRepo>();
            var service = new CustomerService(repo);

            service.GetById(0);

            A.CallTo(() => repo.GetById(0)).MustHaveHappened();
        }

        [Fact]
        public void Add_Invokes_Add()
        {
            var repo = A.Fake<CustomerRepo>();
            var service = new CustomerService(repo);
            var customer = new Customer();
            
            service.Add(customer);

            A.CallTo(() => repo.Add(customer)).MustHaveHappened();
        }

        [Fact]
        public void Update_Invokes_Update()
        {
            var repo = A.Fake<CustomerRepo>();
            var service = new CustomerService(repo);
            var customer = new Customer();
            
            service.Update(customer);

            A.CallTo(() => repo.Update(customer)).MustHaveHappened();
        }

        [Fact]
        public void Delete_Invokes_Delete()
        {
            var repo = A.Fake<CustomerRepo>();
            var service = new CustomerService(repo);
            var customer = new Customer();

            service.Delete(customer);

            A.CallTo(() => repo.Delete(customer)).MustHaveHappened();
        }


    }
}
