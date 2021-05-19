using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestaurantPOS.Models;
using RestaurantPOS.Models.Enums;
using RestaurantPOS.Repositories.Interfaces;

namespace RestaurantPOS.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("Order")]
    public class OrderController : ControllerBase
    {

        public readonly IMenuItemRepository _menuItemRepository;
        public readonly IOrderRepository _orderRepository;
        public readonly IFoodRepository _foodRepository;

        public readonly IConfiguration _configuration;

        public OrderController(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository, IFoodRepository foodRepository, IConfiguration configuration)
        {
            this._orderRepository = orderRepository;
            this._menuItemRepository = menuItemRepository;
            this._foodRepository = foodRepository;
            this._configuration = configuration;
        }

        /// <summary>
        /// Place a customer order in queue.
        /// </summary>
        /// <param name="customerName">Customer's name.</param>
        /// <param name="items">Items ordered by customer.</param>
        /// <returns>True if placed, false if not.</returns>
        [HttpPost("PlaceOrder")]
        public ActionResult PlaceOrder([FromBody] CustomerOrder requestOrder)
        {
            CustomerOrder customerOrder = new CustomerOrder
            {
                CustomerName = requestOrder.CustomerName,
                Done = false,
                Items = requestOrder.Items,
                TotalPrice = 0,
                ID = new Random().Next(1, int.MaxValue)
            };
            List<KitchenOrder> kitchenOrders = new List<KitchenOrder>();

            string[] options = requestOrder.Items.Split('-');

            try
            {
                foreach (var option in options)
                {
                    MenuItem mi = this._menuItemRepository.GetMenuItem(Convert.ToInt32(option));

                    if (mi != null)
                    {
                        foreach (var i in mi.Items.Split('-'))
                        {
                            kitchenOrders.Add(new KitchenOrder
                            {
                                ID = new Random().Next(1, int.MaxValue),
                                CustomerOrderID = customerOrder.ID,
                                FoodID = Convert.ToInt32(i),
                                Done = false,
                                KitchenURL = this.BuildKitchenURI(Convert.ToInt32(i))
                            });
                        }

                        customerOrder.TotalPrice += mi.Price;
                    }
                    else
                    {
                        return BadRequest("Menu item " + option + " does not exist!");
                    }
                }

                if (this._orderRepository.PlaceCustomerOrder(customerOrder) && this._orderRepository.PlaceKitchenOrders(kitchenOrders))
                    return Ok("Order Placed!");
                else
                    return BadRequest("Order could not be placed.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Get All customer Orders.
        /// </summary>
        /// <returns>A list with all Customer Orders.</returns>
        [HttpGet("CustomeOrders")]
        public IEnumerable<CustomerOrder> GetCustomerOrders()
        {
            return this._orderRepository.GetCustomerOrders();
        }

        /// <summary>
        /// Get All Kitchen Orders.
        /// </summary>
        /// <returns>A list with all Kitchen Orders.</returns>
        [HttpGet("kitchenOrders")]
        public IEnumerable<KitchenOrder> GetKitchenOrders()
        {
            return this._orderRepository.GetKitchenOrders();
        }

        /// <summary>
        /// Define the kitchen order URI.
        /// </summary>
        /// <param name="foodID">Food type.</param>
        /// <returns>The Kitchen URI</returns>
        public string BuildKitchenURI(int foodID)
        {
            string toReturn = "";

            switch(this._foodRepository.GetFood(foodID).FoodType)
            {
                case FoodTypeEnum.Baked:
                    toReturn = this._configuration.GetSection("kitchenAPI:Bake").Value;
                    break;
                case FoodTypeEnum.Grilled:
                    toReturn = this._configuration.GetSection("kitchenAPI:Grill").Value;
                    break;
                case FoodTypeEnum.Blendered:
                    toReturn = this._configuration.GetSection("kitchenAPI:Blend").Value;
                    break;
                default:
                    throw new Exception("Unkown Food type");
            }

            return toReturn;
        }

    }
}
