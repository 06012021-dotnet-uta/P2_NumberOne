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
    public class CategoryController : ControllerBase
    {
        db_fetch Fetch = new db_fetch();

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryHandler _categoryHandler;

        public CategoryController(ICategoryHandler CategoryHandler, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _categoryHandler = CategoryHandler;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterCategoryRequest category)
        {
            string error;
            var result = _categoryHandler.CreateCategory(category, out error);

            if (result == null)
                return StatusCode(400, error);
            else
                return StatusCode(201, result);
        }

        [HttpGet("List")]
        public IActionResult CategoryListController()
        {
            var result = _categoryHandler.CategoryList();

            if (result == null)
                return StatusCode(404);
            else
                return StatusCode(201, result);
        }



    }
}
