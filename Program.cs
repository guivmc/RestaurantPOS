using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestaurantPOS.DB;

namespace RestaurantPOS
{
    public class Program
    {
        public static void Main( string[] args )
        {
            DBManager.FoodsDB = DBManager.FoodDBBuilder().ToHashSet();
            DBManager.MenuItemsDB = DBManager.MenuItemDBBuilder().ToHashSet();
            DBManager.CustomerOrderDB = new HashSet<Models.CustomerOrder>();
            DBManager.KitchenOrderDB = new HashSet<Models.KitchenOrder>();

            CreateHostBuilder( args ).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder( string[] args ) =>
            Host.CreateDefaultBuilder( args )
                .ConfigureWebHostDefaults( webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 } );
    }
}
