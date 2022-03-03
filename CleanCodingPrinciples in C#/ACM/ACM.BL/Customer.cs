﻿using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { 
            get {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName)) 
                {
                    if (!string.IsNullOrWhiteSpace(LastName)) fullName += ", ";
                    fullName += FirstName;
                }
                return fullName;
            } 
        }
        public static int InstanceCount { get; set; }
        public string EmailAddress { get; set; }

        /// <summary>
        /// Validates the customer data
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if (String.IsNullOrWhiteSpace(LastName)) return false;
            if (String.IsNullOrWhiteSpace(EmailAddress)) return false;
            return true;
        }

        /// <summary>
        /// Retrive one customer by Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer Retrive(int customerId)
        {
            // Code that retrives the defined customer
            return new Customer();
        }

        /// <summary>
        /// Retrive all customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> Retrive()
        {
            // Code that retrives all of the customers
            return new List<Customer>();
        }

        /// <summary>
        /// Saves the current customer
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined customer
            return true;
        }
    }
}
