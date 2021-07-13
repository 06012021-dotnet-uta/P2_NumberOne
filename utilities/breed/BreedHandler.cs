using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using data_models;
using Microsoft.Extensions.Logging;
using data_models.custom;

namespace utilities
{
    public class BreedHandler : IBreedHandler
    {
        private readonly PetTrackerDBContext _context;
        private readonly ILogger<BreedHandler> _logger;
        private Breed _currentBreed;

        public BreedHandler(PetTrackerDBContext context, ILogger<BreedHandler> logger)
        {
            _context = context;
            _logger = logger;
        }


        public Breed CreateBreed(RegisterBreedRequest regBreed , out string error)
        {
            Breed result = null;
            Category categoryResult = null;
            //Grab ip location info
            try
            {

                //Check to see if category with the same type is already registered to get its id
                categoryResult = _context.Categories.Where(y => y.CategoryId == regBreed.CategoryId).FirstOrDefault();

                //Check to see if Breed with the same type is already registered
                result = _context.Breeds.Where(x => x.Breed1 == regBreed.Breed1 && x.CategoryId == categoryResult.CategoryId).FirstOrDefault();

                //If no customer found then add to db
                if (result == null)
                {
                    //Map RegisterCategoryRequest  type info to category
                    var breed = new Breed
                    {
                        Breed1 = regBreed.Breed1
                    };
                    breed.CategoryId = categoryResult.CategoryId;
                    
                    breed = _context.Add(breed).Entity;
                    _context.SaveChanges();

                    result = breed;
                    _currentBreed = result;
                    error = null;
                }
                else
                {
                    error = "Breed is already exist";
                }



            
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                _currentBreed = null;
                error = "Something went wrong.";
            }
            return result;
        }

        /// <summary>
        /// Accesses the database and returns Breeds entries.
        /// </summary>
        /// <returns>List of Customer entries within the databbase.</returns>
        public List<Breed> BreedList()
        {
            List<Breed> breed = null;
            try
            {
                breed = _context.Breeds.ToList();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
            }
            return breed;
        }

    }
}
