using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data_models;
using data_models.custom;
using utilities;
using utilities.customer;
using Microsoft.Extensions.Logging;
using FindMyPetApi.Controllers;
using data_models;

namespace Testing
{
    public class UnitTest1
    {
        //create in-memory DB
        private DbContextOptions<PetTrackerDBContext> options = new DbContextOptionsBuilder<PetTrackerDBContext>()
             .UseInMemoryDatabase(databaseName: "PetTrackerDB")
             .Options;


        //================================register a customer Test============================
        [Fact]
        public void CreateCustomerTest()
        {
            // Arrange
            string error;
            string ip = "127.0.0.1";
            // Create a customer dummy
            RegisterCustomerRequest customer = new RegisterCustomerRequest
            {
                FirstName = "firstnameTest",
                LastName = "lastname",
                UserName = "username",
                Password = "password",
                Email = "email.gamil.com",
                Phone = 0,
                WanderingRadius = 0,
                ZipCode = 0
            };
            // Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test
                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.
                CustomerHandler customerTest = new CustomerHandler(context);
                customerTest.CreateCustomer(customer, ip, out error);
                context.SaveChanges();
            }
            // Assert
            using (var context = new PetTrackerDBContext(options))
            {
                Customer result = context.Customers.Where(x => x.FirstName == "firstnameTest").FirstOrDefault();
                Assert.NotNull(result);
                Assert.Equal("firstnameTest", result.FirstName);
            }
        }


        //================================register a Category Test============================
        [Fact]
        public void CreateCategoryTest()
        {
            // Arrange
            string error;
            // Create a customer dummy
            RegisterCategoryRequest category = new RegisterCategoryRequest
            {
                 Type="DogTest"
            };
            // Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test
                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.
                CategoryHandler categoryTest = new CategoryHandler(context);
                categoryTest.CreateCategory(category, out error);
                context.SaveChanges();
            }
            // Assert
            using (var context = new PetTrackerDBContext(options))
            {
                Category result = context.Categories.Where(x => x.Type == "DogTest").FirstOrDefault();
                Assert.NotNull(result);
                Assert.Equal("DogTest", result.Type);
            }
        }

        //================================register a Breeding Test============================
        [Fact]
        public void CreateBreedTest()
        {
            // Arrange
            string error;
            // Create a customer dummy
            RegisterBreedRequest breed = new RegisterBreedRequest
            {
                 Breed1="BreedTest",
                 CategoryId=0
            };
            // Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test
                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.
                BreedHandler breedTest = new BreedHandler(context);
                breedTest.CreateBreed(breed, out error);
                context.SaveChanges();
            }
            // Assert
            using (var context = new PetTrackerDBContext(options))
            {
                Breed result = context.Breeds.Where(x => x.Breed1 == "BreedTest").FirstOrDefault();
                Assert.NotNull(result);
                Assert.Equal("BreedTest", result.Breed1);
            }
        }

        //================================List of cutomers Test============================
        [Fact]
        public void ListOfCustomersTest()
        {
            //Arrange

            string error;
            string ip = "127.0.0.1";
            // Create a Cutomer dummy
            RegisterCustomerRequest customer1 = new RegisterCustomerRequest()
            {

                FirstName = "firstnameTest1",
                LastName = "lastname1",
                UserName = "username1",
                Password = "password1",
                Email = "email.gamil.com1",
                Phone = 0,
                WanderingRadius = 0,
                ZipCode = 0
            };

            // Create a Cutomer dummy
            RegisterCustomerRequest customer2 = new RegisterCustomerRequest()
            {

                FirstName = "firstnameTest2",
                LastName = "lastname2",
                UserName = "username2",
                Password = "password2",
                Email = "email.gamil.com2",
                Phone = 0,
                WanderingRadius = 0,
                ZipCode = 0
            };

            // Create a Cutomer dummy
            RegisterCustomerRequest customer3 = new RegisterCustomerRequest()
            {

                FirstName = "firstnameTest3",
                LastName = "lastname3",
                UserName = "username3",
                Password = "password3",
                Email = "email.gamil.com3",
                Phone = 0,
                WanderingRadius = 0,
                ZipCode = 0
            };



            //Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                CustomerHandler customerTest = new CustomerHandler(context);

                customerTest.CreateCustomer(customer1, ip, out error);
                customerTest.CreateCustomer(customer2, ip, out error);
                customerTest.CreateCustomer(customer3, ip, out error);


                context.SaveChanges();
                //Assert

                List<Customer> list2 = customerTest.CustomerList();

                Assert.NotNull(list2);
                Assert.Equal(3, list2.Count());
            }
        }


        //================================List of Catregories Test============================
        [Fact]
        public void ListOfCategoriesTest()
        {
            //Arrange

            string error;
            string ip = "127.0.0.1";
            // Create a Cutomer dummy
            RegisterCategoryRequest Category1 = new RegisterCategoryRequest()
            {
                Type="Anilmal1"
            };

            // Create a Cutomer dummy
            RegisterCategoryRequest Category2 = new RegisterCategoryRequest()
            {
                Type = "Anilmal2"
            };

            // Create a Cutomer dummy
            RegisterCategoryRequest Category3 = new RegisterCategoryRequest()
            {
                Type = "Anilmal3"
            };



            //Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                CategoryHandler CategoryTest = new  CategoryHandler(context);

                CategoryTest.CreateCategory(Category1, out error);
                CategoryTest.CreateCategory(Category2, out error);
                CategoryTest.CreateCategory(Category3, out error);


                context.SaveChanges();
                //Assert

                List<Category> list2 = CategoryTest.CategoryList();

                Assert.NotNull(list2);
                Assert.Equal(3, list2.Count());
            }
        }


        //================================List of Breed Test============================
        [Fact]
        public void ListOfbreedsTest()
        {
            //Arrange

            string error;
            string ip = "127.0.0.1";
            // Create a Cutomer dummy
            RegisterBreedRequest breed1 = new RegisterBreedRequest()
            {
                Breed1 = "Breed1",
                CategoryId = 0
            };

            // Create a Cutomer dummy
            RegisterBreedRequest breed2 = new RegisterBreedRequest()
            {
                Breed1 = "Breed2",
                CategoryId = 0
            };

            // Create a Cutomer dummy
            RegisterBreedRequest breed3 = new RegisterBreedRequest()
            {
                Breed1 = "Breed3",
                CategoryId = 0
            };



            //Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                BreedHandler breedTest = new BreedHandler(context);

                breedTest.CreateBreed(breed1, out error);
                breedTest.CreateBreed(breed2, out error);
                breedTest.CreateBreed(breed3, out error);


                context.SaveChanges();
                //Assert

                List<Breed> list2 = breedTest.BreedList();

                Assert.NotNull(list2);
                Assert.Equal(3, list2.Count());
            }
        }


        //================================ customer Details Test============================
        [Fact]
        public void CustomerDetailsTest()
        {
            // Arrange
            string error;
            string ip = "127.0.0.1";
            // Create a customer dummy
            RegisterCustomerRequest customer = new RegisterCustomerRequest
            {
                FirstName = "firstnameTest",
                LastName = "lastname",
                UserName = "username",
                Password = "password",
                Email = "email.gamil.com",
                Phone = 0,
                WanderingRadius = 0,
                ZipCode = 0
            };
            // Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test
                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.
                CustomerHandler customerTest = new CustomerHandler(context);
                customerTest.CreateCustomer(customer, ip, out error);
                context.SaveChanges();
            }
            // Assert
            using (var context = new PetTrackerDBContext(options))
            {
                CustomerHandler CustomerDetails = new CustomerHandler(context);
                Customer result = CustomerDetails.CustomerDetails(1);
                Assert.NotNull(result);
                Assert.Equal("firstnameTest", result.FirstName);
            }
        }

        //================================ customer Login Test============================
        [Fact]
        public void CustomerLogInTest()
        {
            // Arrange
            string error;
            string ip = "127.0.0.1";
            // Create a customer dummy
            RegisterCustomerRequest customer = new RegisterCustomerRequest
            {
                FirstName = "firstnameTest",
                LastName = "lastname",
                UserName = "username",
                Password = "password",
                Email = "email.gamil.com",
                Phone = 0,
                WanderingRadius = 0,
                ZipCode = 0
            };

            LoginRequest customerLogin = new LoginRequest
            {

                Username = "username",
                Password = "password",
             
            };

            // Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test
                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.
                CustomerHandler customerTest = new CustomerHandler(context);
                customerTest.CreateCustomer(customer, ip, out error);
                context.SaveChanges();
            }
            // Assert
            using (var context = new PetTrackerDBContext(options))
            {
                CustomerHandler CustomerDetails = new CustomerHandler(context);
                Customer result = CustomerDetails.LoginCustomer(customerLogin, out  error);
                Assert.NotNull(result);
                Assert.Equal("firstnameTest", result.FirstName);
            }
        }





    }

}
