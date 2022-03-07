using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class AddressRepository
    {
        public Address Retrive(int addressId)
        {


            // Code that retrives the defined address
            // Tempory hard-coded values to return a populated address
            if (addressId == 1)
            {
                return new Address(addressId)
                {
                    AddressType = 1,
                    streetLine1 = "1114 - Rue principal",
                    streetLine2 = "App 42",
                    PostalCode = "G11 LPL",
                    City = "Québec",
                    StateProvince = "QC",
                    Country = "Canada"
                };
            }

            if (addressId == 2)
            {
                return  new Address(addressId)
                {
                    AddressType = 2,
                    streetLine1 = "444 - Av 1st",
                    PostalCode = "14235",
                    City = "New York",
                    StateProvince = "NY",
                    Country = "US"
                };
            }

            if (addressId == 3)
            {
                return new Address(addressId)
                {
                    AddressType = 1,
                    streetLine1 = "Bag End",
                    streetLine2 = "Bagshot row",
                    PostalCode = "144",
                    City = "Hobbiton",
                    StateProvince = "Shire",
                    Country = "Middle Earth"
                };
            }

            if (addressId == 4)
            {
                return new Address(addressId)
                {
                    AddressType = 2,
                    streetLine1 = "Green Dragon",
                    PostalCode = "146",
                    City = "Bywater",
                    StateProvince = "Shire",
                    Country = "Middle Earth"
                };
            }

            return null;
        }

        public IEnumerable<Address> RetriveByCustomerId(int customerId) 
        {
            var addressList = new List<Address>();
            if(customerId == 1)
            {
                addressList.Add(Retrive(3));
                addressList.Add(Retrive(4));
            }

            return addressList;
            
        }

        public bool Save(Address address)
        {
            // Code that saves the passed address
            return true;
        }
    }
}
