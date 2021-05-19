using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Models
{
    /// <summary>
    /// Represents a menu for the customer.
    /// </summary>
    public class MenuItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Items { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
        public float Discount { get; set; }
    }
}
