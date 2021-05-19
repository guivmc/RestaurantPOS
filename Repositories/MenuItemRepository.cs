using RestaurantPOS.DB;
using RestaurantPOS.Models;
using RestaurantPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        public List<MenuItem> GetAll()
        {
            return DBManager.MenuItemsDB.ToList();
        }

        public MenuItem GetMenuItem(int ID)
        {
            return DBManager.MenuItemsDB.FirstOrDefault(mi => mi.ID == ID);
        }
    }
}
