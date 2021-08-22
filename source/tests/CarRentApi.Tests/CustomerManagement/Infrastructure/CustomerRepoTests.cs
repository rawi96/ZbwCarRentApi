using CarRentApi.CarManagement;
using CarRentApi.CarManagement.Infrastructure;
using CarRentApi.CustomerManagement;
using CarRentApi.CustomerManagement.Infrastructure;
using CarRentApi.Tests.TestResources;
using Xunit;

namespace CarRentApi.Tests.CarManagement.infrastructure
{
    public class CustomerRepoTests
    {
        [Fact]
        public void GetAll_ReturnsValidObjects()
        {
            var customerRepo = new CustomerRepo(new MockContextFactory());

            var retrieved = customerRepo.GetAll();

            Assert.Equal(2, retrieved.Count);
            Assert.Equal("Raphael", retrieved[0].FirstName);
            Assert.Equal("Hans", retrieved[1].FirstName);
        }

        [Fact]
        public void GetById_ReturnsValidObject()
        {
            var customerRepo = new CustomerRepo(new MockContextFactory());

            var retrieved = customerRepo.GetById(1001);

            Assert.Equal("Hans", retrieved.FirstName);
        }

        [Fact]
        public void Add_ReturnsValidObject()
        {
            var customerRepo = new CustomerRepo(new MockContextFactory());

            var ueli = new Customer()
            {
                Id = 2000,
                FirstName = "Ueli"
            };
            var added = customerRepo.Add(ueli);

            Assert.Equal(ueli.FirstName, added.FirstName);
        }
    }
}
