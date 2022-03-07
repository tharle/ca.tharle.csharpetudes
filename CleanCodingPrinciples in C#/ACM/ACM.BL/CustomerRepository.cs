using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }

        private AddressRepository addressRepository { get; set; }
        public Customer Retrive(int customerId)
        {
            

            // Code that retrives the defined customer
            // Tempory hard-coded values to return a populated customer
            if (customerId == 1)
            {
                Customer customer = new Customer(customerId);
                customer.EmailAddress = "fbaggins@hobbiton.me";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
                customer.Addresses = addressRepository.RetriveByCustomerId(customerId).ToList();

                return customer;
            }

            return null;
        }

        public bool Save(Customer customer)
        {
            if (!customer.HasChanges) return true;

            if (!customer.IsValid) return false;

            if (customer.IsNew)
            {
                // Call an Insert Stored PRoducedure
                return true;
            }
            else
            {
                // Call an update stored procedure
                return true;
            }
        }
    }
}
