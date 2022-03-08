using Acme.Common;
using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class Customer : EntityBase, ILoggable
    {
        public Customer(): this(0){ }

        public Customer(int customerId)
        {
            CustomerId = customerId;
            Addresses = new List<Address>();
        }

        public static int InstanceCount { get; set; }

        public int CustomerId { get; private set; }
        public int CustomerType { get; set; }
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
        public string EmailAddress { get; set; }
        public List<Address> Addresses { get; set; }

        public string Log() => $"{CustomerId}: {FullName}; Email: {EmailAddress}; Status: {EntityState.ToString()}";

        public override string ToString() => FullName;

        /// <summary>
        /// Validates the customer data
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (String.IsNullOrWhiteSpace(LastName)) return false;
            if (String.IsNullOrWhiteSpace(EmailAddress)) return false;
            return true;
        }
    }
}
