using RestaurantPOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Place a customer order in the queue.
        /// </summary>
        /// <param name="customerOrder">Customer's order.</param>
        /// <returns>True if order placed, false if not.</returns>
        bool PlaceCustomerOrder(CustomerOrder customerOrder);

        /// <summary>
        /// Get All customer Orders.
        /// </summary>
        /// <returns>A list with all Customer Orders.</returns>
        List<CustomerOrder> GetCustomerOrders();

        /// <summary>
        /// Place kitchen orders.
        /// </summary>
        /// <param name="kitchenOrders">Orders.</param>
        /// <returns>True if order placed, false if not.</returns>
        bool PlaceKitchenOrders(List<KitchenOrder> kitchenOrders);

        /// <summary>
        /// Get All Kitchen Orders.
        /// </summary>
        /// <returns>A list with all Kitchen Orders.</returns>
        List<KitchenOrder> GetKitchenOrders();
    }
}
