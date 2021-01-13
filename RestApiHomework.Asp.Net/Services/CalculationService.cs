using RestApiHomework.Asp.Net.Models;

namespace RestApiHomework.Asp.Net.Services
{
    public class CalculationService
    {
        public void ApplyDiscount(BoughtItem item, Item itemWantToBuy)
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
        }
        public void CalculateTotalPrice(BoughtItem item)
        {
            item.TotalPrice = item.Quantity * item.Price;
        }
    }
}
