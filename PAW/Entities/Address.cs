using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Entities
{
    [Serializable]
    public class Address : Client
    {
        public int AddressId { get; set; }
        public int ClientId { get; set; }
        public string Street { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        public Address() { }
        public Address(int addressId, int clientId, string street, string floor, string apartment)
        {
            AddressId = addressId;
            ClientId = clientId;
            Street = street;
            Floor = floor;
            Apartment = apartment;
        }
        public Address(string street, string floor, string apartment, int addressId)
        {
            Street = street;
            Floor = floor;
            Apartment = apartment;
            AddressId = addressId;
        }
    }
}
