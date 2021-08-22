using AutoMapper;
using CarRentApi.CustomerManagement;
using CarRentApi.CustomerManagement.Api;
using CarRentApi.CustomerManagement.Application;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRentApi.Tests
{
    public class CustomersControllerTests
    {

        [Fact]
        public void Get_Invokes_GetAll()
        {
            var service = A.Fake<CustomerService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CustomersController(service, mapper);

            controller.Get();

            A.CallTo(() => service.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void Get_InvalidId_ReturnsNotFound()
        {
            var service = A.Fake<CustomerService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CustomersController(service, mapper);
            
            A.CallTo(() => service.GetById(0)).Returns(null);

            var result = controller.Get(0);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_ValidId_ReturnsOk()
        {
            var service = A.Fake<CustomerService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CustomersController(service, mapper);
            var customer = new Customer();

            A.CallTo(() => service.GetById(0)).Returns(customer);

            var result = controller.Get(0);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ValidId_ReturnsCreated()
        {
            var service = A.Fake<CustomerService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CustomersController(service, mapper);
            var customerRequest = new CustomerRequestDto();
            var customer = new Customer();

            A.CallTo(() => service.Add(customer)).Returns(customer);

            var result = controller.Post(customerRequest);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void Put_InvalidId_ReturnsNotFound()
        {
            var service = A.Fake<CustomerService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CustomersController(service, mapper);

            A.CallTo(() => service.GetById(0)).Returns(null);

            var result = controller.Put(0, new CustomerRequestDto());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Put_ValidId_ReturnsOk()
        {
            var service = A.Fake<CustomerService>();
            var mapper = A.Fake<IMapper>();
            var controller = new CustomersController(service, mapper);
            var customer = new Customer();

            A.CallTo(() => service.GetById(0)).Returns(customer);

            var result = controller.Put(0, new CustomerRequestDto());

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
