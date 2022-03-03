using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(int customerId)
        {
            CustomerId = customerId;
        }

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
    }
}
