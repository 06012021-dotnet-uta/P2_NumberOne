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



/* ============================= GUILLERMO TEST =============================================*/
         [Fact]
        public void CreateCorrectlyANewForum()
        {
            // Arrange
            string error;

            // Create a forum dummy
            ForumCustom forum = new ForumCustom() {

                ForumName = "My Michu",
                Descriptor = "Lost Pet",
                PetId = 0,
                IsClaimed = true,
            };

            // Act

            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                ForumHandler forumTest = new ForumHandler(context);

                forumTest.CreateNewForum(forum, out error);

                context.SaveChanges();
            }
            // Assert
            using (var context = new PetTrackerDBContext(options))
            {
                Forum forum1 = context.Forums.Where(x => x.ForumName == "My Michu").FirstOrDefault();
                Assert.NotNull(forum1);
                Assert.Equal("Lost Pet", forum1.Descriptor);
                Assert.Equal("My Michu", forum1.ForumName);
                Assert.True(forum1.IsClaimed);
                Assert.Equal(0, forum1.PetId);
                Assert.Equal(1, forum1.ForumId);

            }

        }


        [Fact]
        public void DeleteCorectlyOneForum()
        {
            //Arrange
            string error;
            bool result = false;

            // Create a forum dummy
            ForumCustom forum = new ForumCustom()
            {

                ForumName = "My Michu",
                Descriptor = "Lost Pet",
                PetId = 0,
                IsClaimed = true,
            };
            //Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                ForumHandler forumTest = new ForumHandler(context);

                forumTest.CreateNewForum(forum, out error);

                context.SaveChanges();

                result = forumTest.DeletedForum(1, out error);

                context.SaveChanges();
            }
            //Assert
            using (var context = new PetTrackerDBContext(options))
            {
                Forum forum1 = context.Forums.Where(x => x.ForumName == "My Michu").FirstOrDefault();

                Assert.True(result);
                Assert.Null(forum1);

            }
        }



        [Fact]
        public void CheckListOfForum()
        {
            //Arrange

            string error;

            // Create a forum dummy
            ForumCustom forum1 = new ForumCustom()
            {

                ForumName = "My Michu1",
                Descriptor = "Lost Pet1",
                PetId = 0,
                IsClaimed = true,
            };

            ForumCustom forum2 = new ForumCustom()
            {

                ForumName = "My Michu2",
                Descriptor = "Lost Pet2",
                PetId = 1,
                IsClaimed = true,
            };

            ForumCustom forum3 = new ForumCustom()
            {

                ForumName = "My Michu3",
                Descriptor = "Lost Pet3",
                PetId = 2,
                IsClaimed = true,
            };


            //Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                ForumHandler forumTest = new ForumHandler(context);

                forumTest.CreateNewForum(forum1, out error);
                forumTest.CreateNewForum(forum2, out error);
                forumTest.CreateNewForum(forum3, out error);


                context.SaveChanges();
                //Assert

                List<Forum> list2 = forumTest.ShowForumList(out error);

                Assert.NotNull(list2);
                Assert.Collection(list2,
                item => Assert.Equal(0, item.PetId),
                item => Assert.Equal(1, item.PetId),
                item => Assert.Equal(2, item.PetId)
                );
            }
        }

        [Fact]
        public void TestForSearchForumById()
        {
            //Arrange
            // Arrange
            string error;

            // Create a forum dummy
            ForumCustom forum1 = new ForumCustom()
            {

                ForumName = "My Michu1",
                Descriptor = "Lost Pet1",
                PetId = 0,
                IsClaimed = true,
            };


            ForumCustom forum2 = new ForumCustom()
            {
                ForumName = "My Michu2",
                Descriptor = "Lost Pet2",
                PetId = 1,
                IsClaimed = true,
            };


            //Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                ForumHandler forumTest = new ForumHandler(context);

                forumTest.CreateNewForum(forum1, out error);
                forumTest.CreateNewForum(forum2, out error);
                
                context.SaveChanges();


                //Assert

                Forum test1 = forumTest.SearchForumID(1, out error);
                Forum test2 = forumTest.SearchForumID(2, out error);

                //Assert

                Assert.Equal(1, test1.ForumId);
                Assert.Equal(2, test2.ForumId);

            }    
        }

        [Fact]
        public void TestForSearchForumByPetId()
        {
            
            // Arrange
            string error;

            // Create a forum dummy
            ForumCustom forum1 = new ForumCustom()
            {

                ForumName = "My Michu1",
                Descriptor = "Lost Pet1",
                PetId = 0,
                IsClaimed = true,
            };


            ForumCustom forum2 = new ForumCustom()
            {
                ForumName = "My Michu2",
                Descriptor = "Lost Pet2",
                PetId = 1,
                IsClaimed = true,
            };


            //Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                ForumHandler forumTest = new ForumHandler(context);

                forumTest.CreateNewForum(forum1, out error);
                forumTest.CreateNewForum(forum2, out error);

                context.SaveChanges();


                //Assert

                Forum test1 = forumTest.SearchForumID(1, out error);
                Forum test2 = forumTest.SearchForumID(2, out error);

                //Assert

                Assert.Equal(0, test1.PetId);
                Assert.Equal(1, test2.PetId);

            }


        }

        // ==================== Coloration Test =============== //
        [Fact]
        public void CreateCorrectlyANewColor()
        {

            // Arrange
            string error;

            // Create a coloration dummy
            RegisterColorationRequest coloration = new RegisterColorationRequest()
            {
                Color1 = "White",
                Color2 = "Blue",
                Pattern = "Stripes"
            };


            // Act
            using (var context = new PetTrackerDBContext(options))
            {
                // verify that the db was deleted and created anew
                context.Database.EnsureDeleted();// delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                ColorationHandler colorHandler = new ColorationHandler(context);

                var color = colorHandler.CreateColoration(coloration, out error);

                context.SaveChanges();

                var color2 = context.Colorations.Where(x => x.ColorationId == 1).FirstOrDefault();


                // Assert
                Assert.NotNull(color2);
                Assert.Equal(1, color2.ColorationId);
                Assert.Equal("White", color2.Color1);
                Assert.Equal("Blue", color2.Color2);
                Assert.Equal("Stripes", color2.Pattern);

            }  
        }


        [Fact]
        public void CheckListOfColoration()
        {
            //Arrange
            string error;

            RegisterColorationRequest coloration1 = new RegisterColorationRequest()
            {
                Color1 = "White",
                Color2 = "Blue",
                Pattern = "Stripes"
            };


            RegisterColorationRequest coloration2 = new RegisterColorationRequest()
            {
                Color1 = "Red",
                Color2 = "Yellow",
                Pattern = "Dots"
            };


            RegisterColorationRequest coloration3 = new RegisterColorationRequest()
            {
                Color1 = "Orange",
                Color2 = "Black",
                Pattern = "Solid"
            };

            //Act
            using (var context = new PetTrackerDBContext(options))
            {
                //verify that the db was deleted and created anew
                context.Database.EnsureDeleted();//delete any Db from a previous test

                context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

                ColorationHandler colorHandler = new ColorationHandler(context);

                colorHandler.CreateColoration(coloration1, out error);
                colorHandler.CreateColoration(coloration2, out error);
                colorHandler.CreateColoration(coloration3, out error);


                context.SaveChanges();

                // Assert
                List<Coloration> list2 = colorHandler.ColorationList();

                Assert.NotNull(list2);
                Assert.Collection(list2,
                item => Assert.Equal(1, item.ColorationId),
                item => Assert.Equal(2, item.ColorationId),
                item => Assert.Equal(3, item.ColorationId)
                );

                Assert.Collection(list2,
                item => Assert.Equal("White", item.Color1),
                item => Assert.Equal("Red", item.Color1),
                item => Assert.Equal("Orange", item.Color1)
                );

                Assert.Collection(list2,
                item => Assert.Equal("Blue", item.Color2),
                item => Assert.Equal("Yellow", item.Color2),
                item => Assert.Equal("Black", item.Color2)
                );
            }
        }


    //     // ========================== Pet Test ========================== //

    //     [Fact]
    //     public void AddingAPetToTheApplication()
    //     {

    //         // Arrange
    //         string error;

    //         // Create a forum dummy
    //         Customer customer = new Customer()
    //         {
    //             FirstName = "guest",
    //             LastName = "guest",
    //             UserName = "guest",
    //             Password = "guest",
    //             Email = "guest"
                
    // };

    //         RegisterPetRequest registerPet = new RegisterPetRequest() {

    //              OwnerId = 0,
    //              AggressionCode = 0,
    //              Category = 1,
    //              Gender = 1,
    //              Age = 23,
    //              PetName = "Michu"

    //         };

    //         // Act
    //         using (var context = new PetTrackerDBContext(options))
    //         {

    //             //verify that the db was deleted and created anew
    //             context.Database.EnsureDeleted();//delete any Db from a previous test

    //             context.Database.EnsureCreated();// create a new Db.. you will need to seed it again.

    //             GetMyLocation ip = new GetMyLocation(context);
    //             string myIP = ip.GetMyCoordinate("66.44.7.214");

    //             string[] address = myIP.Split(",");
    //             double latitude = Convert.ToDouble(address[0]);
    //             double longitude = Convert.ToDouble(address[1]);

    //             customer.HomeLocationLatitude = latitude;
    //             customer.HomeLocationLongitude = longitude;

    //             context.Customers.Add(customer);

    //             context.SaveChanges();

    //             LoggedinCustomer log = new LoggedinCustomer();


    //             PetHandler petTest = new PetHandler(context);

    //             petTest.CreatePet(registerPet, out error);

    //             context.SaveChanges();


    //             // Assert
    //             Pet pet = context.Pets.Where(x => x.Name == "Michu").FirstOrDefault();

    //             Assert.NotNull(pet);
    //             /*Assert.Equal("Michu", pet.Name);
    //             Assert.Equal(1, pet.Gender);
    //             Assert.Equal(0, pet.PetId);
    //             Assert.Equal(0, pet.OwnerId);*/
    //         } 

    //     }





    }

}
