using RestaurantPOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Repositories.Interfaces
{
    public interface IFoodRepository
    {
        /// <summary>
        /// Get a Food by its ID.
        /// </summary>
        /// <param name="ID">ID to search for.</param>
        /// <returns>A food.</returns>
        Food GetFood(int ID);
    }
}
