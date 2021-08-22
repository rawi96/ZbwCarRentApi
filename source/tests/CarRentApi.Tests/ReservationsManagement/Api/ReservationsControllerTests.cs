using AutoMapper;
using CarRentApi.ReservationManagement;
using CarRentApi.ReservationManagement.Api;
using CarRentApi.ReservationManagement.Application;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRentApi.Tests
{
    public class ReservationsControllerTests
    {

        [Fact]
        public void Get_Invokes_GetAll()
        {
            var service = A.Fake<ReservationService>();
            var mapper = A.Fake<IMapper>();
            var controller = new ReservationsController(service, mapper);

            controller.Get();

            A.CallTo(() => service.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void Get_InvalidId_ReturnsNotFound()
        {
            var service = A.Fake<ReservationService>();
            var mapper = A.Fake<IMapper>();
            var controller = new ReservationsController(service, mapper);
            
            A.CallTo(() => service.GetById(0)).Returns(null);

            var result = controller.Get(0);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_ValidId_ReturnsOk()
        {
            var service = A.Fake<ReservationService>();
            var mapper = A.Fake<IMapper>();
            var controller = new ReservationsController(service, mapper);
            var reservation = new Reservation();

            A.CallTo(() => service.GetById(0)).Returns(reservation);

            var result = controller.Get(0);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ValidId_ReturnsCreated()
        {
            var service = A.Fake<ReservationService>();
            var mapper = A.Fake<IMapper>();
            var controller = new ReservationsController(service, mapper);
            var reservationRequest = new ReservationRequestDto();
            var reservation = new Reservation();

            A.CallTo(() => service.Add(reservation)).Returns(reservation);

            var result = controller.Post(reservationRequest);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void Put_InvalidId_ReturnsNotFound()
        {
            var service = A.Fake<ReservationService>();
            var mapper = A.Fake<IMapper>();
            var controller = new ReservationsController(service, mapper);

            A.CallTo(() => service.GetById(0)).Returns(null);

            var result = controller.Put(0, new ReservationRequestDto());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Put_ValidId_ReturnsOk()
        {
            var service = A.Fake<ReservationService>();
            var mapper = A.Fake<IMapper>();
            var controller = new ReservationsController(service, mapper);
            var reservation = new Reservation();

            A.CallTo(() => service.GetById(0)).Returns(reservation);

            var result = controller.Put(0, new ReservationRequestDto());

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
