using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Repositories;
using System.Collections.Generic;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopVegetableController : ShopItemController<Vegetable>
    {

        public ShopVegetableController(IBoughtItemsRepository<Vegetable> boughtItemsRepository) : base(boughtItemsRepository)
        {
        }
    }
}
