﻿using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Repositories;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopDishController : ShopItemController<Dish>
    {
        public ShopDishController(IBoughtItemsRepository<Dish> boughtItemsRepository) : base(boughtItemsRepository)
        {
        }
    }
}
