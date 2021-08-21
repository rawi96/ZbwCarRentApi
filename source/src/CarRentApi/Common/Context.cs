using CarRentApi.CarManagement;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarRentApi.Common
{
    public class Context : DbContext
    {
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Database=Cars3; Trusted_Connection=True");
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

            carClasses.ForEach(carClass => modelBuilder.Entity<CarClass>().HasData(carClass));
            cars.ForEach(car => modelBuilder.Entity<Car>().HasData(car));
        }
    }
}
