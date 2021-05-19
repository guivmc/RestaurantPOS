using RestaurantPOS.DB;
using RestaurantPOS.Models;
using RestaurantPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<CustomerOrder> GetCustomerOrders()
        {
            return DBManager.CustomerOrderDB.ToList();
        }

        public List<KitchenOrder> GetKitchenOrders()
        {
            return DBManager.KitchenOrderDB.ToList();
        }

        public bool PlaceCustomerOrder(CustomerOrder customerOrder)
        {
            return DBManager.CustomerOrderDB.Add(customerOrder);
        }

        public bool PlaceKitchenOrders(List<KitchenOrder> kitchenOrders)
        {
            bool success = true;

            foreach(var order in kitchenOrders)
            {
                if (success)
                    success = DBManager.KitchenOrderDB.Add(order);
            }

            return success;
        }
    }
}
