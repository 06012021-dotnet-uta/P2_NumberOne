using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using data_models;
using Microsoft.Extensions.Logging;
using data_models.custom;

namespace utilities
{
    public class CategoryHandler : ICategoryHandler
    {
        private readonly PetTrackerDBContext _context;
        private readonly ILogger<CategoryHandler> _logger;
        private Category _currentCategory;


        public CategoryHandler(PetTrackerDBContext context, ILogger<CategoryHandler> logger)
        {
            _context = context;
            _logger = logger;
            
        }

        
        public Category CreateCategory(RegisterCategoryRequest regCategory, out string error)
        {
            Category result = null;

            //Grab ip location info
            
            try
            {
                //Check to see if category with the same type is already registered
                result = _context.Categories.Where(x => x.Type == regCategory.Type).FirstOrDefault();

                //If no customer found then add to db
                if (result == null)
                {
                    //Map RegisterCategoryRequest  type info to category
                    var category = new Category
                    {
                        Type = regCategory.Type
                    };

                    category = _context.Add(category).Entity;
                    _context.SaveChanges();

                    result = category;
                    _currentCategory = result;
                    error = null;
                }
                else
                {
                    error = "Type is already exist";
                }
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                _currentCategory = null;
                error = "Something went wrong.";
            }

            return result;
        }

        /// <summary>
        /// Accesses the database and returns Customer entries.
        /// </summary>
        /// <returns>List of Customer entries within the databbase.</returns>
        public List<Category> CategoryList()
        {
            List<Category> category = null;
            try
            {
                category = _context.Categories.ToList();
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
            }
            return category;
        }

    }
}
