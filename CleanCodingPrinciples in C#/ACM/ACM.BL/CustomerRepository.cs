﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
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

                return customer;
            }

            return null;
        }

        public bool Save(Customer customer)
        {
            // Code that saves the passed customer
            return true;
        }
    }
}
