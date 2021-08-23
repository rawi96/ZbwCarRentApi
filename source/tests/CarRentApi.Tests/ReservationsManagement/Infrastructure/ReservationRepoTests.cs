using CarRentApi.CarManagement;
using CarRentApi.CarManagement.Infrastructure;
using CarRentApi.ReservationManagement;
using CarRentApi.ReservationManagement.Infrastructure;
using CarRentApi.Tests.TestResources;
using Xunit;

namespace CarRentApi.Tests.CarManagement.infrastructure
{
    public class ReservationRepoTests
    {
        [Fact]
        public void GetAll_ReturnsValidObjects()
        {
            var reservationRepo = new ReservationRepo(new MockContextFactory());

            var retrieved = reservationRepo.GetAll();

            Assert.Single(retrieved);
            Assert.Equal("Raphael", retrieved[0].Customer.FirstName);
        }

        [Fact]
        public void GetById_ReturnsValidObject()
        {
            var reservationRepo = new ReservationRepo(new MockContextFactory());

            var retrieved = reservationRepo.GetById(1000);

            Assert.Equal("Raphael", retrieved.Customer.FirstName);
        }
    }
}
