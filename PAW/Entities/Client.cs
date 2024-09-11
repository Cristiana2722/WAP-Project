using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Entities
{
    [Serializable]
    public class Client : IComparable<Client>
    {
        public Address ClientAddress { get; set; }
        public Pizza ClientPizza { get; set; }
        public int ClientId { get; set; }
        public int AddressId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNo { get; set; }

        public Client() { }
        public Client(int clientId, int addressId, string lastName, string firstName, string phoneNo, Address clientAddress, Pizza clientPizza)
        {
            ClientId = clientId;
            AddressId = addressId;
            LastName = lastName;
            FirstName = firstName;
            PhoneNo = phoneNo;
            ClientAddress = clientAddress;
            ClientPizza = clientPizza;
        }
        public Client(int clientId, int addressId, string lastName, string firstName, string phoneNo)
        {
            ClientId = clientId;
            AddressId = addressId;
            LastName = lastName;
            FirstName = firstName;
            PhoneNo = phoneNo;
        }
        public Client(int clientId, string lastName, string firstName, string phoneNo, string street, string floor, string apartment, string pizzaType, string pizzaSize, int addressId, int pizzaId)
        {
            ClientId = clientId;
            LastName = lastName;
            FirstName = firstName;
            PhoneNo = phoneNo;

            ClientAddress = new Address(street, floor, apartment, addressId);
            ClientPizza = new Pizza(pizzaType, pizzaSize, pizzaId);
        }

        public int CompareTo(Client other)
        {
            return ClientId.CompareTo(other.ClientId);
        }
    }
}
