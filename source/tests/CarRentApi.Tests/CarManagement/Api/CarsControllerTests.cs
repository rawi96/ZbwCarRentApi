using AutoMapper;
using CarRentApi.CarManagement;
using CarRentApi.CarManagement.Api;
using CarRentApi.CarManagement.Application;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRentApi.Tests
{
    public class CarsControllerTests
    {

        [Fact]
        public void Get_Invokes_GetAll()
        {
            var service = A.Fake<CarService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarsController(service, mapper);

            controller.Get();

            A.CallTo(() => service.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void Get_InvalidId_ReturnsNotFound()
        {
            var service = A.Fake<CarService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarsController(service, mapper);
            
            A.CallTo(() => service.GetById(0)).Returns(null);

            var result = controller.Get(0);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_ValidId_ReturnsOk()
        {
            var service = A.Fake<CarService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarsController(service, mapper);
            var car = new Car();

            A.CallTo(() => service.GetById(0)).Returns(car);

            var result = controller.Get(0);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ValidId_ReturnsCreated()
        {
            var service = A.Fake<CarService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarsController(service, mapper);
            var carRequest = new CarRequestDto();
            var car = new Car();

            A.CallTo(() => service.Add(car)).Returns(car);

            var result = controller.Post(carRequest);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void Put_InvalidId_ReturnsNotFound()
        {
            var service = A.Fake<CarService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarsController(service, mapper);

            A.CallTo(() => service.GetById(0)).Returns(null);

            var result = controller.Put(0, new CarRequestDto());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Put_ValidId_ReturnsOk()
        {
            var service = A.Fake<CarService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CarsController(service, mapper);
            var car = new Car();

            A.CallTo(() => service.GetById(0)).Returns(car);

            var result = controller.Put(0, new CarRequestDto());

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
