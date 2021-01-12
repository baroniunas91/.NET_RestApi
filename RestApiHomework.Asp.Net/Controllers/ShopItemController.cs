using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Repositories;
using System.Collections.Generic;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ShopItemController<T> : ControllerBase where T : Item
    {
        private readonly IBoughtItemsRepository<T> _boughtItemsRepository;

        public ShopItemController(IBoughtItemsRepository<T> boughtItemsRepository)
        {
            _boughtItemsRepository = boughtItemsRepository;
        }

        [HttpPost("{id}/{qty}")]
        public void BuyItem(T item, int id, int qty)
        {
            _boughtItemsRepository.BuyItem(item, id, qty);
        }
        [HttpGet]
        public List<BoughtItem> GetBoughtItems()
        {
            return _boughtItemsRepository.GetBoughtItems();
        }

    }
}
