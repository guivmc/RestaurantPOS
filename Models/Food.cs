using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantPOS.Models.Enums;

namespace RestaurantPOS.Models
{
    public class Food
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public FoodTypeEnum FoodType { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
