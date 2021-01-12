using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiHomework.Asp.Net.Repositories
{
    public class BoughtItemsRepository : IBoughtItemsRepository
    {
        private readonly MainContext _context;
        private readonly CalculationService _calculationService;

        public BoughtItemsRepository(MainContext context, CalculationService calculationService)
        {
            _context = context;
            _calculationService = calculationService;
        }
        public void BuyItem(BoughtItem boughtItem)
        {
            var itemWantToBuy = _calculationService.GetRequestedItem(boughtItem, _context);
            if (itemWantToBuy != null)
            {
                boughtItem = _calculationService.ApplyDiscount(boughtItem, itemWantToBuy);
                boughtItem = _calculationService.CalculateTotalPrice(boughtItem);
                _context.BoughtItems.Add(boughtItem);
                _context.SaveChanges();
            }
        }
        public List<BoughtItem> GetBoughtItems()
        {
            return _context.BoughtItems.OrderBy(x => x.Id).ToList();
        }
    }
}
