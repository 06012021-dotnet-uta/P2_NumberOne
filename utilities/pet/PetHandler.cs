using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using data_models;
using Microsoft.Extensions.Logging;
using data_models.custom;
using AutoMapper;
using utilities.Mapper;

namespace utilities
{
    public class PetHandler : IPetHandler
    {
        private readonly PetTrackerDBContext _context;
        private readonly ILogger<PetHandler> _logger;
        private readonly IGetMyLocation _IGetMyLocation;
        private Pet _currentPet;


        public PetHandler(PetTrackerDBContext context, ILogger<PetHandler> logger, IGetMyLocation getMyLocation)
        {
            _context = context;
            _logger = logger;
            _IGetMyLocation = getMyLocation;
        }

        
        public Pet CreatePet(RegisterPetRequest regPet,   out string error)
        {
            Pet result = null;


            try
            {

                                   
                    //Check to see if Pet with username is already registered
                
                    var pet = ObjectMapper.Mapper.Map<RegisterPetRequest, Pet>(regPet);
                pet.OwnerId =  customer.LoggedinCustomer._LoggedInCustomerInfo .CustomerId;

                    pet = _context.Add(pet).Entity;
                    _context.SaveChanges();

                    result = pet;
                    _currentPet = result;
                    error = null;
                
                    error = "This specific Pet that belong to this specific owner is already exist";
                
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                _currentPet = null;
                error = "Something went wrong.";
            }

            return result;
        }

        /// <summary>
        /// Accesses the database and returns Customer entries.
        /// </summary>
        /// <returns>List of Customer entries within the databbase.</returns>
        public List<Pet> PetList()
        {
            List<Pet> pets = null;
            try
            {
                pets = _context.Pets.ToList();
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
            }
            return pets;
        }

        /// <summary>
        /// Accesses the database and returns a Customer object with matching ID.
        /// </summary>
        /// <param name="id">ID of customer to search for.</param>
        /// <returns>Customer object with matching ID.</returns>
        public Pet PetDetails(int id)
        {
            Pet pet = null;
            try
            {
                pet = _context.Pets.Where(x => x.PetId == id).FirstOrDefault();
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
            }
            return pet;
        }



        public Pet  SearchPetByOwnerId(int customerid, out string error)
        {
            Pet pet = null;

            try
            {

                pet = _context.Pets.Where(x => x.OwnerId == customerid).FirstOrDefault();

                if (pet == null)
                {
                    error = "customerID not found in the DB";

                }
                else
                {
                    error = null;

                }

            }
            catch (ArgumentNullException e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                error = "Something Wrong in SearchPetByOwnerID() method";
            }

            return pet;
        }


        //======================================================================
        // to display all gender list
        //======================================================================
        public List<Gender> GenderList()
        {
            List<Gender> genders = null;
            try
            {
                genders = _context.Genders.ToList();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
            }
            return genders;
        }
        public Gender SearchGenderById(int genderid, out string error)
        {
            Gender gender = null;

            try
            {

                gender = _context.Genders.Where(x => x.Code == genderid).FirstOrDefault();

                if (gender == null)
                {
                    error = "Gender Code not found in the DB";

                }
                else
                {
                    error = null;

                }

            }
            catch (ArgumentNullException e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                error = "Something Wrong in SearchGenderByID() method";
            }

            return gender;
        }
        //======================================================================
        // to display all Aggression list
        //======================================================================

        public List<AggressionCode> AggressionCodeList()
        {
            List<AggressionCode> aggressioncodes = null;
            try
            {
                aggressioncodes = _context.AggressionCodes.ToList();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
            }
            return aggressioncodes;
        }
        public AggressionCode SearchAggressionCodeById(int aggressioncodeid, out string error)
        {
            AggressionCode aggressioncodes = null;

            try
            {

                aggressioncodes = _context.AggressionCodes.Where(x => x.Code == aggressioncodeid).FirstOrDefault();

                if (aggressioncodes == null)
                {
                    error = "Aggression Code not found in the DB";

                }
                else
                {
                    error = null;

                }

            }
            catch (ArgumentNullException e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                error = "Something Wrong in SearchaggressioncodesByID() method";
            }

            return aggressioncodes;
        }
    }
}
