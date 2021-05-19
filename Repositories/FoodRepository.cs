using RestaurantPOS.DB;
using RestaurantPOS.Models;
using RestaurantPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        public Food GetFood(int ID)
        {
            return DBManager.FoodsDB.FirstOrDefault(f => f.ID == ID);
        }
    }
}
