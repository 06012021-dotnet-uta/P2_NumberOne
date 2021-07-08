using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class CustomerHandler : ICustomerHandler
    {
        private PetTrackerDBContext _context;
        private static Customer _currentCustomer;


        public static Customer currentCustomer
        {
            get
            {
                return _currentCustomer;
            }
            set
            {
                _currentCustomer = value;

            }
        }


        public CustomerHandler(PetTrackerDBContext context)
        {
            this._context = context;
        }



        /// <summary>
        /// Returns string with result of checking customer credentials.
        /// </summary>
        /// <param name="username">Username of customer.</param>
        /// <param name="password">Password of customer.</param>
        /// <returns>String with result of attempting to login with given credentials</returns>
        public string LoginCustomer(string username, string password)
        {
            string result = "";
            try
            {
                var temp = _context.Customers.Where(x => x.UserName == username).FirstOrDefault();
                if (temp != null)
                {
                    if (temp.Password == password)
                    {
                        currentCustomer = temp;
                        result = "You are successfully logged in";
                    }
                    else
                    {
                        result = "Password does not match, please try again.";
                    }
                }
                else
                {
                    result = "There is no Customer with that username. Please try again or create a new account.";
                }
            }
            catch (Exception)
            {
                // put log info here
                result = "Something went wrong.";
                return result;
            }
            return result;
        }



        public bool Add(Customer customer)
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
