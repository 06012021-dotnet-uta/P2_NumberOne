using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using data_models;

namespace utilities
{
    public interface ICustomerHandler
    {
        bool Add(Customer customer);
        List<Customer> CustomerList();
        string LoginCustomer(string username, string password);
        Customer SearchCustomer(int id);
        
    }
}