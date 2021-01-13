using AutoMapper;
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
        private readonly IMapper _mapper;

        public BoughtItemsRepository(MainContext context, CalculationService calculationService, IMapper mapper)
        {
            _context = context;
            _calculationService = calculationService;
            _mapper = mapper;
        }
        public void BuyItem(T item, int id, int qty)
        {
            var itemWantToBuy = _context.Set<T>().Where(i => i.Id == id).SingleOrDefault();
            if (itemWantToBuy != null)
            {
                var boughtItem = _mapper.Map<BoughtItem>(itemWantToBuy);
                boughtItem.Quantity = qty; 
                _calculationService.ApplyDiscount(boughtItem, itemWantToBuy);
                _calculationService.CalculateTotalPrice(boughtItem);
                _context.BoughtItems.Add(boughtItem);
                _context.SaveChanges();
            } else
            {
                throw new Exception();
            }
        }
        public List<BoughtItem> GetBoughtItems()
        {
            return _context.BoughtItems.OrderBy(x => x.Id).ToList();
        }
    }
}
