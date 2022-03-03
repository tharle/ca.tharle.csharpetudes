using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Address
    {
        public Address(){}
        public Address(int addressId) { AddressId = addressId; }
        public int AddressId { get; private set; }
        public string streetLine1 { get; set; }
        public string streetLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }

        public bool Validate() {
            if (String.IsNullOrWhiteSpace(streetLine1) && String.IsNullOrWhiteSpace(streetLine2)) return false;
            if (String.IsNullOrWhiteSpace(City)) return false;
            if (String.IsNullOrWhiteSpace(StateProvince)) return false;
            if (String.IsNullOrWhiteSpace(Country)) return false;
            if (String.IsNullOrWhiteSpace(PostalCode)) return false;
            return true;
        }
    }
}
