using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiHomework.Asp.Net.Repositories
{
    public class BoughtItemsRepository<T> : IBoughtItemsRepository<T> where T : Item
    {
        private readonly MainContext _context;
        private readonly CalculationService _calculationService;

        public BoughtItemsRepository(MainContext context, CalculationService calculationService)
        {
            _context = context;
            _calculationService = calculationService;
        }
        public void BuyItem(T item, int id, int qty)
        {
            var boughtItem = new BoughtItem();
            var itemWantToBuy = _context.Set<T>().Where(i => i.Id == id).SingleOrDefault();
            if (itemWantToBuy != null)
            {
                _calculationService.ApplyName(boughtItem, itemWantToBuy);
                _calculationService.ApplyQuantity(boughtItem, qty);
                _calculationService.ApplyDiscount(boughtItem, itemWantToBuy);
                _calculationService.CalculateTotalPrice(boughtItem);
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
