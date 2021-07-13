using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using data_models;
using Microsoft.Extensions.Logging;
using data_models.custom;

namespace utilities
{
    public class ColorationHandler : IColorationHandler
    {
        private readonly PetTrackerDBContext _context;
        private readonly ILogger<ColorationHandler> _logger;
        private  Coloration _currentColoration;


        public ColorationHandler(PetTrackerDBContext context, ILogger<ColorationHandler> logger)
        {
            _context = context;
            _logger = logger;
            
        }

        
        public Coloration CreateColoration(RegisterColorationRequest regColoration, out string error)
        {
            Coloration result = null;

            //Grab ip location info
            
            try
            {
                //Check to see if Coloration with the same colors and patern is already registered
                //result = _context.Colorations.Where (x => x.Color1 == regColoration.Color1 && x.Color2 == regColoration.Color2 && x.Pattern == regColoration.Pattern).FirstOrDefault();

                //If no customer found then add to db
                //if (result == null)
                //{
                    //Map RegisterCategoryRequest  type info to category
                    var coloration = new Coloration
                    {
                        Color1 = regColoration.Color1,
                        Color2 = regColoration.Color2,
                        Pattern = regColoration.Pattern

                    };

                    coloration = _context.Add(coloration).Entity;
                    _context.SaveChanges();

                    result = coloration;
                    _currentColoration = result;
                    error = null;
                //}
                //else
                //{
                //    error = "Type is already exist";
                //}
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                _currentColoration = null;
                error = "Something went wrong.";
            }

            return result;
        }

        /// <summary>
        /// Accesses the database and returns Customer entries.
        /// </summary>
        /// <returns>List of Customer entries within the databbase.</returns>
        public List<Coloration> ColorationList()
        {
            List<Coloration> coloration = null;
            try
            {
                coloration = _context.Colorations.ToList();
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
            }
            return coloration;
        }

    }
}
