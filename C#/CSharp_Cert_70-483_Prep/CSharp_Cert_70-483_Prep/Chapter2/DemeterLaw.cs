using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Cert_70_483_Prep.Chapter2
{
    class DemeterLaw
    {


        public Distance CalculateDistanceTo(Customer customer)
        {
            // Some difficult calculation that uses customer.Address
            Distance result = new Distance(customer.HomeAddress.miles);
            return result;
        }

        // This method avoids using the Customer class as it is only needed to
        // get the address. This is one dependency less, so it is better.
        public Distance CalculateDistanceTo(Address address)
        {
            // Some difficult calculation that uses address
            Distance result = new Distance(address.miles);
            return result;
        }
    }

    struct Distance
    {
        public int dist;

        public Distance(int dist)
        {
            this.dist = dist;
        }
    }

    struct Address
    {
        public int miles;
    }

    class Customer
    {
        public Address HomeAddress { get; set; }
    }
}
