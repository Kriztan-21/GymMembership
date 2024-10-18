using MANAGER.CustomerService;
using static MODEL.CustomerModel;
using System.Collections.Generic;
using System.Linq;

namespace MANAGER.CustomerManager
{
    public class CustomerManager : ICustomerService
    {
        // Temporary data for testing before database connections
        private readonly List<Customer> _customers = new List<Customer>
        {
            new Customer { Id = 1, FirstName = "John", LastName = "Doe", Type = "Computer Science" },
            new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Type = "Information Technology" }
        };

        // Function that displays all customers within the list
        public IEnumerable<Customer> GetAllCustomer()
        {
            return _customers; // Return the list of customers
        }

        // Function to display the details of the customer if there is a matching Id
        public Customer GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id); // Use _customers
        }

        // Function that adds a customer to the list
        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
            }

            customer.Id = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1; // Get new ID
            _customers.Add(customer); // Add the customer
        }

        // Function that updates a customer's information if it exists
        public void UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.Id == id); // Use _customers
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Type = customer.Type;
            }
        }

        // Function that deletes a customer from the list
        public void DeleteCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id); // Use _customers
            if (customer != null)
            {
                _customers.Remove(customer); // Remove the customer
            }
        }

        // Explicit interface implementation (if needed, remove if not)
        IEnumerable<Customer> ICustomerService.GetAllCustomer()
        {
            return GetAllCustomer(); // Call the public method
        }

        Customer ICustomerService.GetCustomerById(int id)
        {
            return GetCustomerById(id); // Call the public method
        }

        void ICustomerService.AddCustomer(Customer customer)
        {
            AddCustomer(customer); // Call the public method
        }

        void ICustomerService.UpdateCustomer(int id, Customer customer)
        {
            UpdateCustomer(id, customer); // Call the public method
        }

        void ICustomerService.DeleteCustomer(int id)
        {
            DeleteCustomer(id); // Call the public method
        }
    }
}
