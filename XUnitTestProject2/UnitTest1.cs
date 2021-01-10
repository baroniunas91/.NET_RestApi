using FluentAssertions;
using Moq;
using RestApiHomework.Asp.Net.Controllers;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Repositories;
using RestApiHomework.Asp.Net.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject2
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
        [Fact]
        public void TestApplyDiscount()
        {
            var boughtItem = new BoughtItem();
            var itemWantToBuy = new Dish();
            var calculationService = new CalculationService();

            boughtItem.Quantity = 4;
            calculationService.ApplyDiscount(boughtItem, itemWantToBuy);
            boughtItem.Price.Should().Be(3);

            boughtItem.Quantity = 7;
            calculationService.ApplyDiscount(boughtItem, itemWantToBuy);
            boughtItem.Price.Should().Be(2.7M);

            boughtItem.Quantity = 12;
            calculationService.ApplyDiscount(boughtItem, itemWantToBuy);
            boughtItem.Price.Should().Be(2.4M);
        }

        [Fact]
        public void FirstControllerTest()
        {
            var mockBoughtItemsRepository = new Mock<IBoughtItemsRepository>();

            mockBoughtItemsRepository.Setup(m => m.GetBoughtItems()).Returns(new List<BoughtItem>()
            {
                new BoughtItem()
                {
                    Type = "Dishes",
                    Name = "Plate",
                    Price = 2,
                    Quantity = 3,
                    Discount = 0,
                    TotalPrice = 6
                },
                new BoughtItem()
                {
                    Type = "Dishes",
                    Name = "Knife",
                    Price = 2,
                    Quantity = 3,
                    Discount = 0,
                    TotalPrice = 6
                }
            });

            var shopController = new ShopController(mockBoughtItemsRepository.Object);

            shopController.GetBoughtItems().Should().HaveCount(2);
        }
    }
}
