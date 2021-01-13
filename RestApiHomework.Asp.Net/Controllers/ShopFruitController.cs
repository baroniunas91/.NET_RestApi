using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Repositories;
using System.Collections.Generic;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopFruitController : ShopItemController<Fruit>
    {
        public ShopFruitController(IBoughtItemsRepository<Fruit> boughtItemsRepository) : base(boughtItemsRepository)
        {
        }
    }
}
