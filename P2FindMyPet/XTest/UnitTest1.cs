using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using BusinessLayer;
using DataLayer;
using RepostoryLayer;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace XTest
{
    public class UnitTest1
    {
        //create in-memory DB
        DbContextOptions<FindMyPetDBContext> options = new DbContextOptionsBuilder<FindMyPetDBContext>().UseInMemoryDatabase(databaseName: "TestingDb").Options;

        private readonly IConfigurationRoot configuration;

        public UnitTest1()
        {
            configuration = new ConfigurationBuilder()
               .AddUserSecrets<UnitTest1>()
               .Build();
        }

        [Fact]
        public void AddCustomerSuccess()
        {
            using (var context = new FindMyPetDBContext(options))
            {
                // arrange
                bool result;
                Customer customer = new Customer()
                {
                    FirstName = "fname",
                    LastName = "lName",
                    Username = "username",
                    Password = "password",
                    ZipCode = "zipcode",
                    Phone = "phone",
                    Email = "email",
                    HomeCoordinate = "homecoordinate",
                    WanderingRadius = "wanderingradius"
                };
                // act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                CustomerHandler customerHandler = new CustomerHandler(context);
                result = customerHandler.Add(customer);

                // assert
                Assert.True(result);
            }
        }

        
        [Fact]
        public void LoginIncorrectPw()
        {
            using (var context = new FindMyPetDBContext(options))
            {
                // arrange
                Customer customer = new Customer()
                {
                    FirstName = "fname",
                    LastName = "lName",
                    Username = "username",
                    Password = "password"
                };
                // act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                CustomerHandler customerHandler = new CustomerHandler(context);
                customerHandler.Add(customer);
                string test = customerHandler.LoginCustomer(customer.Username, "Incorrect password");

                // assert
                Assert.NotEqual("", test);
            }
        }


        [Fact]
        public void LoginIncorrectUsername()
        {
            using (var context = new FindMyPetDBContext(options))
            {
                // arrange
                Customer customer = new Customer()
                {
                    FirstName = "fname",
                    LastName = "lName",
                    Username = "username",
                    Password = "password"
                };
                // act
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                CustomerHandler customerHandler = new CustomerHandler(context);
                customerHandler.Add(customer);
                string test = customerHandler.LoginCustomer("wrongName", customer.Password);

                // assert
                Assert.NotEqual("", test);
            }
        }

        [Fact]
        public void GetClientLocationCoordinates()
        {
            using (var context = new FindMyPetDBContext(options))
            {
                // arrange
                CustomerHandler customerHandler = new CustomerHandler(context, configuration);
                LocationCoords expectedLC = new LocationCoords() { latitude = -33.86714172363281f, longitude = 151.2071075439453f };

                // act
                LocationCoords lc = customerHandler.GetLocation("1.1.1.1");

                // assert
                Assert.Equal(expectedLC, lc);
            }
        }


    }


}