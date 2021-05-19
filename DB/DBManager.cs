using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantPOS.Models;
using RestaurantPOS.Models.Enums;

namespace RestaurantPOS.DB
{
    /// <summary>
    /// Static methods to manage in memory DBs.
    /// </summary>
    public class DBManager
    {
        public static HashSet<Food> FoodsDB { get; set; }
        public static HashSet<MenuItem> MenuItemsDB { get; set; }
        public static HashSet<CustomerOrder> CustomerOrderDB { get; set; }
        public static HashSet<KitchenOrder> KitchenOrderDB { get; set; }

        public static List<Food> FoodDBBuilder()
        {
            List<Food> DB = new List<Food>();

            #region Grilled
            DB.Add(new Food { Description = "Hamburger", Amount = 10, Price = 15f, FoodType = FoodTypeEnum.Grilled, ID = 0 });
            DB.Add(new Food { Description = "Filet Mignon", Amount = 15, Price = 35f, FoodType = FoodTypeEnum.Grilled, ID = 10 });
            DB.Add(new Food { Description = "Bacon", Amount = 55, Price = 7f, FoodType = FoodTypeEnum.Grilled, ID = 20 });
            #endregion

            #region Baked
            DB.Add(new Food { Description = "Coockie", Amount = 40, Price = 6f, FoodType = FoodTypeEnum.Baked, ID = 30 });
            DB.Add(new Food { Description = "Petit Gateau", Amount = 20, Price = 12f, FoodType = FoodTypeEnum.Baked, ID = 40 });
            DB.Add(new Food { Description = "Red Velvet", Amount = 5, Price = 15f, FoodType = FoodTypeEnum.Baked, ID = 50 });
            #endregion

            #region Blendered
            DB.Add(new Food { Description = "Coca", Amount = 5, Price = 3f, FoodType = FoodTypeEnum.Blendered, ID = 60 });
            DB.Add(new Food { Description = "Vodka", Amount = 5, Price = 5f, FoodType = FoodTypeEnum.Blendered, ID = 70 });
            DB.Add(new Food { Description = "Apple Juice", Amount = 5, Price = 2f, FoodType = FoodTypeEnum.Blendered, ID = 80 });
            #endregion

            return DB;
        }

        public static List<MenuItem> MenuItems()
        {
            List<MenuItem> DB = new List<MenuItem>();

            #region Combos
            DB.Add(new MenuItem { Name = "Combo - Burgui Feliz", Description = "Hamburger + Coca + Coockie", Items = "0-30-60", Discount = 3f, ID = 100 });
            DB.Add(new MenuItem { Name = "Combo - Tristeza", Description = "Vodka + Coca + Coockie", Items = "70-30-60", Discount = 3f, ID = 110 });
            DB.Add(new MenuItem { Name = "Combo - Almoco", Description = "Filet Mignon + Apple Juice + Petit Gateau", Items = "10-80-40", Discount = 9f, ID = 120 });
            #endregion

            DB.Add(new MenuItem { Name = "Hamburger", Description = "Hamburger", Items = "0", ID = 0 });
            DB.Add(new MenuItem { Name = "Filet Mignon", Description = "Filet Mignon", Items = "10", ID = 10 });
            DB.Add(new MenuItem { Name = "Bacon", Description = "Bacon", Items = "20", ID = 20 });

            DB.Add(new MenuItem { Name = "Coockie", Description = "Coockie", Items = "30", ID = 30 });
            DB.Add(new MenuItem { Name = "Petit Gateau", Description = "Petit Gateau", Items = "40", ID = 40 });
            DB.Add(new MenuItem { Name = "Red Velvet", Description = "Red Velvet", Items = "50", ID = 50 });

            DB.Add(new MenuItem { Name = "Coca", Description = "Coca", Items = "60", ID = 60 });
            DB.Add(new MenuItem { Name = "Vodka", Description = "Vodka", Items = "70", ID = 70 });
            DB.Add(new MenuItem { Name = "Apple Juice", Description = "Apple Juice", Items = "80", ID = 80 });

            return DB;
        }

        public static List<MenuItem> MenuItemDBBuilder()
        {
            List<MenuItem> Menu = new List<MenuItem>();

            foreach (var option in DBManager.MenuItems())
            {
                string[] contents = option.Items.Split('-');
                bool available = true;
                float price = 0;

                foreach (var content in contents)
                {
                    Food food = DBManager.FoodsDB.FirstOrDefault(f => f.ID == Convert.ToInt32(content));
                    if (food != null)
                    {
                        available = available && (food.Amount > 0); //If has food and previous foods were available then -> available = true;
                        price += food.Price;
                    }
                    else
                        available = false;
                }

                Menu.Add(new MenuItem
                {
                    ID = option.ID,
                    Available = available,
                    Description = option.Description,
                    Items = option.Items,
                    Discount = option.Discount,
                    Name = option.Name,
                    Price = price - option.Discount,
                });
            }

            return Menu;
        }
    }
}
