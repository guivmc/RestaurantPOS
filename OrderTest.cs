using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using RestaurantPOS.Controllers;
using RestaurantPOS.DB;
using RestaurantPOS.Models;
using RestaurantPOS.Models.Enums;
using RestaurantPOS.Repositories;
using RestaurantPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest
{
    public class OrderTest
    {
        public OrderController orderController { get; set; }
        public IConfiguration configTest { get; set; }

        [SetUp]
        public void Setup()
        {
            //build DB
            DBManager.FoodsDB = DBManager.FoodDBBuilder().ToHashSet();
            DBManager.MenuItemsDB = DBManager.MenuItemDBBuilder().ToHashSet();
            DBManager.CustomerOrderDB = new HashSet<CustomerOrder>();
            DBManager.KitchenOrderDB = new HashSet<KitchenOrder>();

            //Build test config
            configTest = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "ApplicationName", "Test" },
                })
                .Build();
        }

        [Test]
        public void BuildKitchenURITestSuccess()
        {
            //Prep
            Mock<IFoodRepository> foodRepoMock = new Mock<IFoodRepository>();
            foodRepoMock.Setup(m => m.GetFood(0)).Returns(new Food { FoodType = FoodTypeEnum.Grilled });

            Mock<IConfiguration> configMock = new Mock<IConfiguration>();
            configMock.Setup(m => m.GetSection("kitchenAPI:Grill")).Returns(this.configTest.GetSection("ApplicationName"));

            this.orderController = new OrderController(new OrderRepository(), new MenuItemRepository(), foodRepoMock.Object, configMock.Object);

            //Act AND Assert
            Assert.NotNull(this.orderController.BuildKitchenURI(0), "Kicthen URL should not be null!");
        }

        [Test]
        public void BuildKitchenURITestFail()
        {
            //Prep
            Mock<IFoodRepository> foodRepoMock = new Mock<IFoodRepository>();
            foodRepoMock.Setup(m => m.GetFood(0)).Returns(new Food());

            Mock<IConfiguration> configMock = new Mock<IConfiguration>();
            configMock.Setup(m => m.GetSection("kitchenAPI:Grill")).Returns(this.configTest.GetSection("ApplicationName"));

            this.orderController = new OrderController(new OrderRepository(), new MenuItemRepository(), foodRepoMock.Object, configMock.Object);

            //Act AND Assert
            var ex = Assert.Throws<Exception>(() => this.orderController.BuildKitchenURI(0), "Should have thrown an exception here!");
            Assert.That(ex.Message, Is.EqualTo("Unkown Food type"));
        }

    }
}
