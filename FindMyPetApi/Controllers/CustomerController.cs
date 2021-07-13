using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using utilities;
using data_models;
using data_models.custom;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        db_fetch Fetch = new db_fetch();

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerHandler _customerHandler;
        
        public CustomerController(ICustomerHandler customerHandler, ILogger<CustomerController> logger)
        {
            _logger = logger;
            _customerHandler = customerHandler;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            string error;
            var result = _customerHandler.LoginCustomer(loginRequest, out error);
            
            
            if(result == null)
                return StatusCode(401, error);
            else
            {
                return StatusCode(200, result);
                
            }
        }
        
        [HttpPost("Register")]
        public IActionResult Register(RegisterCustomerRequest customer, string ip)
        {
            string error;
            var result = _customerHandler.CreateCustomer(customer, ip, out error);

            if (result == null)
                return StatusCode(400, error);
            else
                return StatusCode(201, result);
        }

        [HttpGet("List")]
        public IActionResult CutomerListController()
        {
            var result = _customerHandler.CustomerList();

            if (result == null)
                return StatusCode(404);
            else
                return StatusCode(201, result);
        }

        [HttpGet("Details/{id}")]
        public IActionResult CustomerDetails(int id)
        {
            var result = _customerHandler.CustomerDetails(id);

            if (result == null)
                return StatusCode(404);
            else
                return StatusCode(200, result);
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






    }
}
