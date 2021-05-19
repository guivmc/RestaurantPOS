using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Models
{
    /// <summary>
    /// Represents one item in one Customer Order.
    /// </summary>
    public class KitchenOrder
    {
        public int ID { get; set; }
        public int CustomerOrderID { get; set; }
        public int FoodID { get; set; }
        public bool Done { get; set; }
        public string KitchenURL { get; set; }
    }
}
