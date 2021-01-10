using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using System.Linq;

namespace RestApiHomework.Asp.Net.Services
{
    public class CalculationService
    {
        public Item GetRequestedItem(BoughtItem boughtItem, MainContext context)
        {
            Item itemWantToBuy = null;
            if (boughtItem.Type == "Dishes")
            {
                itemWantToBuy = context.Dishes.Where(i => i.Name == boughtItem.Name).SingleOrDefault();
            }
            else if (boughtItem.Type == "Fruits")
            {
                itemWantToBuy = context.Fruits.Where(i => i.Name == boughtItem.Name).SingleOrDefault();
            }
            else if (boughtItem.Type == "Vegetables")
            {
                itemWantToBuy = context.Vegetables.Where(i => i.Name == boughtItem.Name).SingleOrDefault();
            }
            if (itemWantToBuy != null)
            {
                boughtItem.Name = itemWantToBuy.Name;
            }
            return itemWantToBuy;
        }

        public BoughtItem ApplyDiscount(BoughtItem item, Item itemWantToBuy)
        {
            if(item.Quantity >= 5 && item.Quantity < 10)
            {
                item.Discount = 10;
                item.Price = itemWantToBuy.Price * (100 - item.Discount) / 100;

            } else if(item.Quantity >= 10)
            {
                item.Discount = 20;
                item.Price = itemWantToBuy.Price * (100 - item.Discount) / 100;
            } else
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
