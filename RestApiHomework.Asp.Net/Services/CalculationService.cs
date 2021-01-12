using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using System;
using System.Linq;

namespace RestApiHomework.Asp.Net.Services
{
    public class CalculationService
    {
        public BoughtItem ApplyName(BoughtItem item, Item itemWantToBuy)
        {
            if (itemWantToBuy != null)
            {
                item.Name = itemWantToBuy.Name;
                return item;
            }
            return null;
        }

        public BoughtItem ApplyQuantity(BoughtItem item, int qty)
        {
            item.Quantity = qty;
            return item;
        }

        public BoughtItem ApplyDiscount(BoughtItem item, Item itemWantToBuy)
        {
            if (item.Quantity >= 5 && item.Quantity < 10)
            {
                item.Discount = 10;
                item.Price = itemWantToBuy.Price * (100 - item.Discount) / 100;

            }
            else if (item.Quantity >= 10)
            {
                item.Discount = 20;
                item.Price = itemWantToBuy.Price * (100 - item.Discount) / 100;
            }
            else
            {
                item.Discount = 0;
                item.Price = itemWantToBuy.Price;
            }
            return item;
        }
        public BoughtItem CalculateTotalPrice(BoughtItem item)
        {
            item.TotalPrice = item.Quantity * item.Price;
            return item;
        }
    }
}
