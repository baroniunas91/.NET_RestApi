using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Services;
using System.Collections.Generic;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FruitController : ItemController<Fruit>
    {
        public FruitController(IItemService<Fruit> itemService, MainContext context) : base(itemService, context)
        {
        }
    }
}

