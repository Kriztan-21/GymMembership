using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MODEL.CustomerModel;

namespace MANAGER.CustomerService
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(int id, Customer customer);
        void DeleteCustomer(int id);
    }
}