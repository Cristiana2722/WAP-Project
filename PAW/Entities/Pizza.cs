using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Entities
{
    [Serializable]
    public class Pizza : Client
    {
        public int PizzaId { get; set; }
        public int ClientId { get; set; }
        public string PizzaType { get; set; }
        public string PizzaSize { get; set; }
        public Pizza() { }
        public Pizza(int pizzaId, int clientId, string pizzaType, string pizzaSize)
        {
            PizzaId = pizzaId;
            ClientId = clientId;
            PizzaType = pizzaType;
            PizzaSize = pizzaSize;
        }
        public Pizza(string pizzaType, string pizzaSize)
        {
            PizzaType = pizzaType;
            PizzaSize = pizzaSize;
        }
        public Pizza(string pizzaType, string pizzaSize, int pizzaId)
        {
            PizzaType = pizzaType;
            PizzaSize = pizzaSize;
            PizzaId = pizzaId;
        }
    }
}
