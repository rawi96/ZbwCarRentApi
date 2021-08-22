using CarRentApi.CarManagement;
using CarRentApi.CarManagement.Infrastructure;
using CarRentApi.Tests.TestResources;
using Xunit;

namespace CarRentApi.Tests.CarManagement.infrastructure
{
    public class CarRepoTests
    {
        [Fact]
        public void GetAll_ReturnsValidObjects()
        {
            var carRepo = new CarRepo(new MockContextFactory());

            var retrieved = carRepo.GetAll();

            Assert.Equal(2, retrieved.Count);
            Assert.Equal("Volvo", retrieved[0].Brand);
            Assert.Equal("Audi", retrieved[1].Brand);
        }

        [Fact]
        public void GetById_ReturnsValidObject()
        {
            var carRepo = new CarRepo(new MockContextFactory());

            var retrieved = carRepo.GetById(1001);

            Assert.Equal("Audi", retrieved.Brand);
        }
    }
}
