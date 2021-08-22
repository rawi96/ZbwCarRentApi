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
    }
}
