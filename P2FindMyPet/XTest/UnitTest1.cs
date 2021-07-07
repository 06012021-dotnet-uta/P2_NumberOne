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


namespace XTest
{
    public class UnitTest1
    {
        //create in-memory DB
        DbContextOptions<FindMyPetDBContext> options = new DbContextOptionsBuilder<FindMyPetDBContext>().UseInMemoryDatabase(databaseName: "TestingDb").Options;

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


    }


}