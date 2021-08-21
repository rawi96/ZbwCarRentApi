using AutoMapper;
using CarRentApi.CarManagement;
using CarRentApi.CarManagement.Api;
using CarRentApi.CarManagement.Application;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRentApi.Tests
{
    public class CarClassesControllerTests
    {

        [Fact]
        public void Get_Invokes_GetAll()
        {
            var service = A.Fake<CarClassService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarClassesController(service, mapper);

            controller.Get();

            A.CallTo(() => service.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void Get_InvalidId_ReturnsNotFound()
        {
            var service = A.Fake<CarClassService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarClassesController(service, mapper);
            
            A.CallTo(() => service.GetById(0)).Returns(null);

            var result = controller.Get(0);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_ValidId_ReturnsOk()
        {
            var service = A.Fake<CarClassService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarClassesController(service, mapper);
            var carClass = new CarClass();

            A.CallTo(() => service.GetById(0)).Returns(carClass);

            var result = controller.Get(0);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ValidId_ReturnsCreated()
        {
            var service = A.Fake<CarClassService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarClassesController(service, mapper);
            var carClassRequest = new CarClassRequestDto();
            var carClass = new CarClass();

            A.CallTo(() => service.Add(carClass)).Returns(carClass);

            var result = controller.Post(carClassRequest);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void Put_InvalidId_ReturnsNotFound()
        {
            var service = A.Fake<CarClassService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarClassesController(service, mapper);

            A.CallTo(() => service.GetById(0)).Returns(null);

            var result = controller.Put(0, new CarClassRequestDto());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Put_ValidId_ReturnsOk()
        {
            var service = A.Fake<CarClassService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarClassesController(service, mapper);
            var carClass = new CarClass();

            A.CallTo(() => service.GetById(0)).Returns(carClass);

            var result = controller.Put(0, new CarClassRequestDto());

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
