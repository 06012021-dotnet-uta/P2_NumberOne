using RepostoryLayer;
using System.Collections.Generic;
using DataLayer;
namespace BusinessLayer
{
    public interface ICustomerHandler
    {
        bool Add(Customer customer);
        List<Customer> CustomerList();
        string LoginCustomer(string username, string password);
        Customer SearchCustomer(int id);
    }
}