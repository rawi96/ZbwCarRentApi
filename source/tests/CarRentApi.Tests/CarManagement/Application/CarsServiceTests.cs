using CarRentApi.CarManagement;
using CarRentApi.CarManagement.Application;
using CarRentApi.CarManagement.Infrastructure;
using FakeItEasy;
using Xunit;

namespace CarRentApi.Tests
{
    public class CarServiceTests
    {

        [Fact]
        public void GetAll_Invokes_GetAll()
        {
            var repo = A.Fake<CarRepo>();
            var service = new CarService(repo);

            service.GetAll();

            A.CallTo(() => repo.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void GetById_Invokes_GetById()
        {
            var repo = A.Fake<CarRepo>();
            var service = new CarService(repo);

            service.GetById(0);

            A.CallTo(() => repo.GetById(0)).MustHaveHappened();
        }

        [Fact]
        public void Add_Invokes_Add()
        {
            var repo = A.Fake<CarRepo>();
            var service = new CarService(repo);
            var car = new Car();
            
            service.Add(car);

            A.CallTo(() => repo.Add(car)).MustHaveHappened();
        }

        [Fact]
        public void Update_Invokes_Update()
        {
            var repo = A.Fake<CarRepo>();
            var service = new CarService(repo);
            var car = new Car();
            
            service.Update(car);

            A.CallTo(() => repo.Update(car)).MustHaveHappened();
        }

        [Fact]
        public void Delete_Invokes_Delete()
        {
            var repo = A.Fake<CarRepo>();
            var service = new CarService(repo);
            var car = new Car();

            service.Delete(car);

            A.CallTo(() => repo.Delete(car)).MustHaveHappened();
        }


    }
}
