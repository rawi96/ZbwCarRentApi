using CarRentApi.CarManagement;
using CarRentApi.CarManagement.Infrastructure;
using CarRentApi.Tests.TestResources;
using Xunit;

namespace CarRentApi.Tests.CarManagement.infrastructure
{
    public class CarClassRepoTests
    {
        [Fact]
        public void GetAll_ReturnsValidObjects()
        {
            var carClassRepo = new CarClassRepo(new MockContextFactory());

            var retrieved = carClassRepo.GetAll();

            Assert.Equal(3, retrieved.Count);
            Assert.Equal("Luxury", retrieved[0].Description);
            Assert.Equal("Medium", retrieved[1].Description);
            Assert.Equal("Basic", retrieved[2].Description);
        }

        [Fact]
        public void GetById_ReturnsValidObject()
        {
            var carClassRepo = new CarClassRepo(new MockContextFactory());

            var retrieved = carClassRepo.GetById(1001);

            Assert.Equal("Medium", retrieved.Description);
        }

        [Fact]
        public void Add_ReturnsValidObject()
        {
            var carClassRepo = new CarClassRepo(new MockContextFactory());

            var awesome = new CarClass()
            {
                Id = 1001,
                Description = "Awesome",
                PricePerDay = 100
            };
            var added = carClassRepo.Add(awesome);

            Assert.Equal(awesome.Description, added.Description);
        }

        [Fact]
        public void Update_ReturnsValidObject()
        {
            var carClassRepo = new CarClassRepo(new MockContextFactory());

            var awesome = new CarClass()
            {
                Id = 1001,
                Description = "Awesome",
                PricePerDay = 100
            };
            var updated = carClassRepo.Update(awesome);

            Assert.Equal(awesome.Description, updated.Description);
        }
    }
}
