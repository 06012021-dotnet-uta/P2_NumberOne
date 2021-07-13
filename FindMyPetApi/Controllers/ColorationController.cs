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
    public class ColorationController : ControllerBase
    {
        db_fetch Fetch = new db_fetch();

        private readonly ILogger<ColorationController> _logger;
        private readonly IColorationHandler _colorationHandler;

        public ColorationController(IColorationHandler ColorationHandler, ILogger<ColorationController> logger)
        {
            _logger = logger;
            _colorationHandler = ColorationHandler;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterColorationRequest coloration)
        {
            string error;
            var result = _colorationHandler.CreateColoration(coloration, out error);

            if (result == null)
                return StatusCode(400, error);
            else
                return StatusCode(201, result);
        }

        [HttpGet("List")]
        public IActionResult ColorationListController()
        {
            var result = _colorationHandler.ColorationList();

            if (result == null)
                return StatusCode(404);
            else
                return StatusCode(201, result);
        }



    }
}
