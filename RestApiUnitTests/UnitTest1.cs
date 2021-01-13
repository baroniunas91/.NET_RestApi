using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RestApiHomework.Asp.Net.Controllers;
using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Repositories;
using RestApiHomework.Asp.Net.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RestApiUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCalculateTotalPrice()
        {
            //Arange
            var boughtItem = new BoughtItem();
            var calculationService = new CalculationService();
            //Act
            calculationService.CalculateTotalPrice(boughtItem);
            //Assert
            boughtItem.TotalPrice.Should().Be(200);
        }
        [Theory]
        [InlineData(3, 4)]
        [InlineData(2.7, 7)]
        [InlineData(2.4, 12)]
        public void TestApplyDiscount(decimal priceShouldBe, int quantity)
        {
            var boughtItem = new BoughtItem();
            var itemWantToBuy = new Dish();
            var calculationService = new CalculationService();

            boughtItem.Quantity = quantity;
            calculationService.ApplyDiscount(boughtItem, itemWantToBuy);
            boughtItem.Price.Should().Be(priceShouldBe);
        }

        [Fact]
        public void ShopControllerTest()
        {
            var fixture = new Fixture();
            var boughtItem1 = fixture.Build<BoughtItem>().Without(c => c.Id).Create();
            var boughtItem2 = fixture.Build<BoughtItem>().Without(c => c.Id).Create();

            var mockBoughtItemsRepository = new Mock<IBoughtItemsRepository<Dish>>();

            mockBoughtItemsRepository.Setup(m => m.GetBoughtItems()).Returns(new List<BoughtItem>()
            {
                boughtItem1,
                boughtItem2
            });

            var shopController = new ShopDishController(mockBoughtItemsRepository.Object);
            shopController.GetBoughtItems().Should().HaveCount(2);
        }
        [Fact]
        public async Task DishControllerAddAndGetTest()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<MainContext>()
                      .UseInMemoryDatabase(databaseName: "MockDB")
                      .Options;
            var context = new MainContext(options);
            var repository = new ItemRepository<Dish>(context);
            var controller = new DishController(repository);
            var dish = new Dish();
            //Act
            await controller.Post(dish);
            var items = await controller.Get();
            //Asert
            //3 seeded in MainContext constructor and 1 I attached here, total 4
            items.Count.Should().Be(4);
        }
    }
}
