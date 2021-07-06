using LogInRepostoryLayer;
using System.Collections.Generic;
using LogInDataLayer;
namespace LogInBusinessLayer
{
    public interface ICustomerHandler
    {
        bool Add(Customer customer);
        List<Customer> CustomerList();
        string LoginCustomer(string username, string password);
        Customer SearchCustomer(int id);
    }
}