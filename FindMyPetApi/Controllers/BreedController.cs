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
    public class BreedController : ControllerBase
    {
        db_fetch Fetch = new db_fetch();

        private readonly ILogger<BreedController> _logger;
        private readonly IBreedHandler _breedHandler;

        public BreedController(IBreedHandler BreedHandler, ILogger<BreedController> logger)
        {
            _logger = logger;
            _breedHandler = BreedHandler;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterBreedRequest breed)
        {
           
            string error;
            var result = _breedHandler.CreateBreed(breed, out error);

            if (result == null)
                return StatusCode(400, error);
            else
                return StatusCode(201, result);
        }

        [HttpGet("List")]
        public IActionResult BreedListController()
        {
            var result = _breedHandler.BreedList();

            if (result == null)
                return StatusCode(404);
            else
                return StatusCode(201, result);
        }



    }
}
