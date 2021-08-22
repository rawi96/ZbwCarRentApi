using CarRentApi.ReservationManagement;
using CarRentApi.ReservationManagement.Application;
using CarRentApi.ReservationManagement.Infrastructure;
using FakeItEasy;
using Xunit;

namespace CarRentApi.Tests
{
    public class ReservationServiceTests
    {

        [Fact]
        public void GetAll_Invokes_GetAll()
        {
            var repo = A.Fake<ReservationRepo>();
            var service = new ReservationService(repo);

            service.GetAll();

            A.CallTo(() => repo.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void GetById_Invokes_GetById()
        {
            var repo = A.Fake<ReservationRepo>();
            var service = new ReservationService(repo);

            service.GetById(0);

            A.CallTo(() => repo.GetById(0)).MustHaveHappened();
        }

        [Fact]
        public void Add_Invokes_Add()
        {
            var repo = A.Fake<ReservationRepo>();
            var service = new ReservationService(repo);
            var reservation = new Reservation();
            
            service.Add(reservation);

            A.CallTo(() => repo.Add(reservation)).MustHaveHappened();
        }

        [Fact]
        public void Update_Invokes_Update()
        {
            var repo = A.Fake<ReservationRepo>();
            var service = new ReservationService(repo);
            var reservation = new Reservation();
            
            service.Update(reservation);

            A.CallTo(() => repo.Update(reservation)).MustHaveHappened();
        }

        [Fact]
        public void Delete_Invokes_Delete()
        {
            var repo = A.Fake<ReservationRepo>();
            var service = new ReservationService(repo);
            var reservation = new Reservation();

            service.Delete(reservation);

            A.CallTo(() => repo.Delete(reservation)).MustHaveHappened();
        }


    }
}
