using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using data_models;
using Microsoft.Extensions.Logging;
using data_models.custom;

namespace utilities
{
    public class CustomerHandler : ICustomerHandler
    {
        private readonly PetTrackerDBContext _context;
        private readonly ILogger<CustomerHandler> _logger;
        private readonly IGetMyLocation _IGetMyLocation;
        private Customer _currentCustomer;


        public CustomerHandler(PetTrackerDBContext context, ILogger<CustomerHandler> logger, IGetMyLocation getMyLocation)
        {
            _context = context;
            _logger = logger;
            _IGetMyLocation = getMyLocation;
        }



        /// <summary>
        /// Returns string with result of checking customer credentials.
        /// </summary>
        /// <param name="username">Username of customer.</param>
        /// <param name="password">Password of customer.</param>
        /// <returns>String with result of attempting to login with given credentials</returns>
        public Customer LoginCustomer(LoginRequest loginRequest, out string error)
        {
            try
            {
                var temp = _context.Customers.Where(x => x.UserName == loginRequest.Username).FirstOrDefault();
                if (temp != null)
                {
                    if (temp.Password == loginRequest.Password)
                    {
                        _currentCustomer = temp;
                        error = null;
                    }
                    else
                    {
                        error = "Password does not match, please try again.";
                    }
                }
                else
                {
                    error = "There is no Customer with that username. Please try again or create a new account.";
                }
            }
            catch (Exception e)
            {
                // put log info here
                _logger.Log(LogLevel.Error, e.Message);
                _currentCustomer = null;
                error = "Something went wrong.";
            }

            return _currentCustomer;
        }

        
        public Customer CreateCustomer(RegisterCustomerRequest regCustomer, string ip, out string error)
        {
            Customer result = null;

            //Grab ip location info
            string myaddress = _IGetMyLocation.GetMyCoordinate(ip);
            string[] address = myaddress.Split(",");
            double latitude = Convert.ToDouble(address[0]);
            double longitude = Convert.ToDouble(address[1]);

            try
            {
                //Check to see if customer with username is already registered
                result = _context.Customers.Where(x => x.UserName == regCustomer.UserName).FirstOrDefault();

                //If no customer found then add to db
                if (result == null)
                {
                    //Map RegisterCustomerRequest to Customer
                    var customer = new Customer
                    {
                        FirstName = regCustomer.FirstName,
                        LastName = regCustomer.LastName,
                        UserName = regCustomer.UserName,
                        Password = regCustomer.Password,
                        Email = regCustomer.Email,
                        HomeLocationLatitude = latitude,
                        HomeLocationLongitude = longitude,
                        WanderingRadius = regCustomer.WanderingRadius,
                        Phone = regCustomer.Phone,
                        ZipCode = regCustomer.ZipCode,
                        AccountCreationDate = DateTime.Now
                    };

                    customer = _context.Add(customer).Entity;
                    _context.SaveChanges();

                    result = customer;
                    _currentCustomer = result;
                    error = null;
                }
                else
                {
                    error = "User name is already exist";
                }
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                _currentCustomer = null;
                error = "Something went wrong.";
            }

            return result;
        }
        



        public bool Add(RegisterCustomerRequest customer)
        {
            bool success = false;
            try
            {
                _context.Add(customer);
                _context.SaveChanges();
                success = true;
            }
            catch (Exception)
            {
                //log stuff
                return success;
            }

            return success;
        }

        /// <summary>
        /// Accesses the database and returns Customer entries.
        /// </summary>
        /// <returns>List of Customer entries within the databbase.</returns>
        public List<Customer> CustomerList()
        {
            List<Customer> customers = null;
            try
            {
                customers = _context.Customers.ToList();
            }
            catch
            {
                Console.WriteLine("Exception.");
            }
            return customers;
        }

        /// <summary>
        /// Accesses the database and returns a Customer object with matching ID.
        /// </summary>
        /// <param name="id">ID of customer to search for.</param>
        /// <returns>Customer object with matching ID.</returns>
        public Customer SearchCustomer(int id)
        {
            Customer customer = null;
            try
            {
                customer = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            }
            catch
            {
                Console.WriteLine("Exception.");
            }
            return customer;
        }

        /// <summary>
        /// Accesses the database to get PreferedStore entry for customer with matching customer ID.
        /// </summary>
        /// <param name="customerId">ID of customer to search for preferred store.</param>
        /// <returns>PreferredStore entry that contains customer ID.</returns>
    }
}
