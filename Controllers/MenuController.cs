using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Models;
using RestaurantPOS.Repositories.Interfaces;

namespace RestaurantPOS.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route( "Menu" )]
    public class MenuController :  ControllerBase
    {

        public readonly IMenuItemRepository _menuItemRepository;
        public readonly IFoodRepository _foodRepository;

        public MenuController(IFoodRepository foodRepository, IMenuItemRepository menuItemRepository)
        {
            this._foodRepository = foodRepository;
            this._menuItemRepository = menuItemRepository;
        }

        /// <summary>
        /// Get a menu for the customer to select its desired items.
        /// </summary>
        /// <returns>A menu for the customer.</returns>
        [HttpGet("CustomerMenu")]
        public IEnumerable<MenuItem> GetCustomerMenu()
        {
            return this._menuItemRepository.GetAll();
        }


    }
}
