using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using data_models;

namespace Testing
{
    public class UnitTest1
    {
        private DbContextOptions<PetTrackerDBContext> options;

        public UnitTest1()
        {
            options = new DbContextOptionsBuilder<PetTrackerDBContext>()
             .UseInMemoryDatabase(databaseName: "PetTrackerDB")
             .Options;
        }
    }
}
