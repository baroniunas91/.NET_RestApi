using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Repositories;
using RestApiHomework.Asp.Net.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IBoughtItemsRepository _boughtItemsRepository;

        public ShopController(IBoughtItemsRepository boughtItemsRepository)
        {
            _boughtItemsRepository = boughtItemsRepository;
        }

        [HttpPost]
        public void BuyItem(BoughtItem item)
        {
            _boughtItemsRepository.BuyItem(item);
        }
        [HttpGet]
        public List<BoughtItem> GetBoughtItems()
        {
            return _boughtItemsRepository.GetBoughtItems();
        }

    }
}
