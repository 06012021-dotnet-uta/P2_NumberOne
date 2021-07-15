using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using utilities;
using data_models;
using data_models.custom;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindMyPetApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        db_fetch Fetch = new db_fetch();

        private readonly ILogger<PetController> _logger;
        private readonly IPetHandler _petHandler;
        private readonly ICustomerHandler _customerHandler;

        public PetController(IPetHandler petHandler, ICustomerHandler customerHandler, ILogger<PetController> logger)
        {
            _logger = logger;
            _petHandler = petHandler;
            _customerHandler = customerHandler;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterPetRequest pet,  string ip)
        {
            string error;
            var result = _petHandler.CreatePet(pet,  out error);

            if (result == null)
                return StatusCode(400, error);
            else
                return StatusCode(201, result);
        }

        [HttpGet("List")]
        public IActionResult PetListController()
        {
            var result = _petHandler.PetList();

            if (result == null)
                return StatusCode(404);
            else
                return StatusCode(201, result);
        }

        [HttpGet("Details/{id}")]
        public IActionResult PetDetails(int id)
        {
            var result = _petHandler.PetDetails(id);

            if (result == null)
                return StatusCode(404);
            else
                return StatusCode(200, result);
        }


        [HttpGet("SearchPetByOwnserId/{id}")]
        public IActionResult SearchPetByOwnserId(int customerID)
        {
            string error;

            var pet = _petHandler.SearchPetByOwnerId(customerID, out error);

            if (pet == null)
            {
                return StatusCode(400, error);
            }
            else
            {
                return StatusCode(200);
            }
        }






    }
}
