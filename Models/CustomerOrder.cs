using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Models
{
    /// <summary>
    /// Represents an Order made by a customer
    /// </summary>
    public class CustomerOrder
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public float TotalPrice { get; set; }
        public string Items { get; set; }
        public bool Done { get; set; }
    }
}
