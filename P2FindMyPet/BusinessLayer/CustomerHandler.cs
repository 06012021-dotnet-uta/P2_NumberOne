using Microsoft.AspNetCore.Http;
using System.Text.Json;
using RepostoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DataLayer;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace BusinessLayer
{
    public class CustomerHandler : ICustomerHandler
    {
        private FindMyPetDBContext _context;
        private readonly IConfiguration _configuration;
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

        
        public CustomerHandler(FindMyPetDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public CustomerHandler(FindMyPetDBContext context)
        {
            _context = context;
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
                var temp = _context.Customers.Where(x => x.Username == username).FirstOrDefault();
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

        /// <summary>
        /// Obtains location of a customer through the use of ipstack.
        /// </summary>
        /// <param name="IpAddress">Ip address to obtain location</param>
        /// <returns>LocationCoords object containing location coordinates. Returns null if unsuccessful</returns>
        public LocationCoords GetLocation(string IpAddress)
        {
            //Grab the ip address of client connection
            string clientIpAddress = IpAddress;
            
            //Throw exception if unable to get client connection ip
            if(clientIpAddress.Length <= 0)
            {
                throw new Exception("Unable to obtain client ip address");
            }

            //Api key and url with parameters | Docs => https://ipstack.com/documentation
            string apiKey = _configuration["ApiKey"];
            string url = $"http://api.ipstack.com/{clientIpAddress}?access_key={apiKey}&fields=latitude,longitude";
            
            //For testing
            //string testingurl = $"http://api.ipstack.com/1.1.1.1?access_key={apiKey}&fields=latitude,longitude";

            using (WebClient client = new WebClient())
            {
                //Grab the json response from api
                string json = client.DownloadString(url);

                try
                {
                    //Deserialize json response to LocationCoords obj and return if successful
                    LocationCoords location = JsonSerializer.Deserialize<LocationCoords>(json);
                    return location;
                }
                catch(Exception e)
                {
                    //For uh-oh's in deserialization
                    Console.WriteLine("Unable to deserialize ipstack response\n");
                    Console.WriteLine(e.Message);

                    return null;
                }
            }
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
                customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
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
