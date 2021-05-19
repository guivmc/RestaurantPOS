using RestaurantPOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        /// <summary>
        /// Get all menu items.
        /// </summary>
        /// <returns>All menu items.</returns>
        List<MenuItem> GetAll();

        /// <summary>
        /// Get a menu item by its ID.
        /// </summary>
        /// <param name="ID">ID to search for.</param>
        /// <returns>A menu item.</returns>
        MenuItem GetMenuItem(int ID);
    }
}
