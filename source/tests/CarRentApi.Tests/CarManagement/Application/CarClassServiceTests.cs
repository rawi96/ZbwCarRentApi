using CarRentApi.CarManagement;
using CarRentApi.CarManagement.Application;
using CarRentApi.CarManagement.Infrastructure;
using FakeItEasy;
using Xunit;

namespace CarRentApi.Tests
{
    public class CarClassServiceTests
    {

        [Fact]
        public void GetAll_Invokes_GetAll()
        {
            var repo = A.Fake<CarClassRepo>();
            var service = new CarClassService(repo);

            service.GetAll();

            A.CallTo(() => repo.GetAll()).MustHaveHappened();
        }

        [Fact]
        public void GetById_Invokes_GetById()
        {
            var repo = A.Fake<CarClassRepo>();
            var service = new CarClassService(repo);

            service.GetById(0);

            A.CallTo(() => repo.GetById(0)).MustHaveHappened();
        }

        [Fact]
        public void Add_Invokes_Add()
        {
            var repo = A.Fake<CarClassRepo>();
            var service = new CarClassService(repo);
            var carClass = new CarClass();
            
            service.Add(carClass);

            A.CallTo(() => repo.Add(carClass)).MustHaveHappened();
        }

        [Fact]
        public void Update_Invokes_Update()
        {
            var repo = A.Fake<CarClassRepo>();
            var service = new CarClassService(repo);
            var carClass = new CarClass();
            
            service.Update(carClass);

            A.CallTo(() => repo.Update(carClass)).MustHaveHappened();
        }

        [Fact]
        public void Delete_Invokes_Delete()
        {
            var repo = A.Fake<CarClassRepo>();
            var service = new CarClassService(repo);
            var carClass = new CarClass();

            service.Delete(carClass);

            A.CallTo(() => repo.Delete(carClass)).MustHaveHappened();
        }


    }
}
