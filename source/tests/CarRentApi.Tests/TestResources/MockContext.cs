using CarRentApi.CarManagement;
using CarRentApi.Common;
using CarRentApi.CustomerManagement;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarRentApi.Tests.TestResources
{
    public class MockContext : Context
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "database_name");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var luxury = new CarClass()
            {
                Id = 1000,
                Description = "Luxury",
                PricePerDay = 200
            };

            var medium = new CarClass()
            {
                Id = 1001,
                Description = "Medium",
                PricePerDay = 100
            };

            var basic = new CarClass()
            {
                Id = 1002,
                Description = "Basic",
                PricePerDay = 50
            };


            var volvoV50 = new Car()
            {
                Id = 1000,
                Brand = "Volvo",
                Model = "V50",
                LicensePlate = "SG 456845",
                CarClassId = medium.Id
            };

            var audiA8 = new Car()
            {
                Id = 1001,
                Brand = "Audi",
                Model = "A8",
                LicensePlate = "TG 34253",
                CarClassId = luxury.Id
            };

            var raphael = new Customer()
            {
                Id = 1000,
                FirstName = "Raphael",
                LastName = "Wirth",
                Street = "Musterstrasse",
                StreetNumber = "12a",
                Zip = 9000,
                Place = "St. Gallen",
                Country = "Switzerland"
            };

            var hans = new Customer()
            {
                Id = 1001,
                FirstName = "Hans",
                LastName = "Müller",
                Street = "Bahnhofweg",
                StreetNumber = "24",
                Zip = 9403,
                Place = "Goldach",
                Country = "Switzerland"
            };

            List<CarClass> carClasses = new List<CarClass>
            {
                luxury,
                medium,
                basic
            };

            List<Car> cars = new List<Car>
            {
                volvoV50,
                audiA8
            };

            List<Customer> customers = new List<Customer>
            {
                raphael,
                hans
            };

            carClasses.ForEach(carClass => modelBuilder.Entity<CarClass>().HasData(carClass));
            cars.ForEach(car => modelBuilder.Entity<Car>().HasData(car));
            customers.ForEach(customer => modelBuilder.Entity<Customer>().HasData(customer));
        }
    }
}
