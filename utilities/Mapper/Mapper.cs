using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using data_models;
using data_models.custom;

namespace utilities.Mapper
{
    public static class ObjectMapper
    {
        private static readonly MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>{
            /*
             * ...Add mapper configs here...
             * 
             * Example: cfg.CreateMap<CustomModel, DbModel>();
             * 
             * then call "var dbObj = ObjectMapper.Mapper.Map<<CustomModel, DbModel>(customObj);" to use
             * 
             * */
            cfg.CreateMap<RegisterCustomerRequest, Customer>();
            cfg.CreateMap<RegisterPetRequest, Pet>();
            cfg.CreateMap<CurrentLoggedInCustomer, Customer>();
            cfg.CreateMap<ForumCustom, Forum>();
        });

        public static IMapper Mapper = _mapperConfig.CreateMapper();
    }
}
