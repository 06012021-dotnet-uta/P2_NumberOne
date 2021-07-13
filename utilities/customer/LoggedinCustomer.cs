using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using data_models;
using Microsoft.Extensions.Logging;
using data_models.custom;
using AutoMapper;
using utilities.Mapper;

namespace utilities.customer
{
    public class LoggedinCustomer
    {
        public static Customer _LoggedInCustomerInfo;



        public  Customer LoggedInCustomerInfo
        {
            get
            {
                return _LoggedInCustomerInfo ;
            }
            set
            {
                _LoggedInCustomerInfo = value;


            }
        }

    }
}
