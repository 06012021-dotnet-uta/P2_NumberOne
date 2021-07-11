using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using data_models;
using data_models.custom;

namespace utilities
{
    public interface ICustomerHandler
    {
        Customer CreateCustomer(RegisterCustomerRequest customer, string ip, out string error);
        List<Customer> CustomerList();
        Customer LoginCustomer(LoginRequest loginRequest, out string error);
        Customer CustomerDetails(int id);
        
    }
}