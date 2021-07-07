using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using System.Net;
using RepostoryLayer;
using javax.swing;
using Newtonsoft.Json;
using System.Globalization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ICustomerHandler _customerHandler;
        public LoginController(ICustomerHandler customerHandler, ILogger<LoginController> logger)
        {
            this._logger = logger;
            this._customerHandler = customerHandler;
        }



        [HttpPost("Login")]

        public string Login(string username, string password)
        {

            string result = _customerHandler.LoginCustomer(username, password);
            return result; ;
        }


        
        [HttpPost("CreateCustomer")]
        
        public string CreateCustomer(Customer customer)
        {
            string result = _customerHandler.LoginCustomer(customer.Username, customer.Password);
            if (result == "There is no Customer with that username. Please try again or create a new account.")
            {
                bool success = _customerHandler.Add(customer);
                if (success)
                {
                    result = "Your registration process is completed";

                }
                else
                {
                    result = "Somthing wrong happened during registration";

                }

            }
            else
            {
                result = "User name is already exist";

            }
            return result;

        }



        // GET: a
        // pi/<LoginController>
/*        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        } */

        [HttpGet("CutomerListController")]
        public List<Customer> CutomerListController()
        {

            List<Customer> cusomerlist = _customerHandler.CustomerList();

            return cusomerlist;
        }


        //=====================to get the cliet IP Address==================================
        
        [HttpGet("GetUserAddressByIp")]
        public  IpInfo GetUserAddressByIp(string ip)
            {
                IpInfo ipInfo = new IpInfo();
                try
                {
                    string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                    ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                    RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                    RegionInfo myRI2 = new RegionInfo(ipInfo.City);
                    RegionInfo myRI3 = new RegionInfo(ipInfo.Postal);
                    RegionInfo myRI4 = new RegionInfo(ipInfo.Ip);
                    RegionInfo myRI5 = new RegionInfo(ipInfo.Loc);
                    RegionInfo myRI6 = new RegionInfo(ipInfo.Org);
                    RegionInfo myRI7 = new RegionInfo(ipInfo.Region);
                    RegionInfo myRI8 = new RegionInfo(ipInfo.Hostname);
                }
                catch (Exception)
                {

                }

                return ipInfo;
            }

            //=====================End of  cliet IP Address==================================
        

    }
}
