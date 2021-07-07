using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using LogInRepostoryLayer;
using LogInDataLayer;
using LogInBusinessLayer;
using System.Collections.Generic;




namespace XTest
{
    public class UnitTest1
    {
        //create in-memory DB
        DbContextOptions<LogInRepostory> options = new DbContextOptionsBuilder<LogInRepostory>().UseInMemoryDatabase(databaseName: "TestingDb").Options;

        [Fact]
        public void AddCustomerSuccess()
        {
            using (var context = new LogInRepostory(options))
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


        public void LoginSuccess()
        {
            using (var context = new LogInRepostory(options))
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
                string test = customerHandler.LoginCustomer(customer.Username, customer.Password);

                // assert
                Assert.Equal("", test);
            }
        }


    }

}