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
            cfg.CreateMap<RegisterCustomerRequest, Customer>();
        });

        public static IMapper Mapper = _mapperConfig.CreateMapper();
    }
}
