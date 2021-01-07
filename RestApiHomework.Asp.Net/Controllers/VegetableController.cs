using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Services;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VegetableController : ItemController<Vegetable>
    {
        public VegetableController(IItemService<Vegetable> itemService, MainContext context) : base(itemService, context)
        {
        }
    }
}
