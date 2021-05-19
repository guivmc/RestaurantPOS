using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPOS.Models.Enums
{
    /// <summary>
    /// Enum to define the type of a food.
    /// Food type is used to know who is responsable for it.
    /// </summary>
    public enum FoodTypeEnum
    {
        /// <summary>
        /// Burguers
        /// </summary>
        Grilled = 1,
        /// <summary>
        /// Desserts
        /// </summary>
        Baked = 2, 
        /// <summary>
        /// Juices and other drinks
        /// </summary>
        Blendered = 3,
    }
}
