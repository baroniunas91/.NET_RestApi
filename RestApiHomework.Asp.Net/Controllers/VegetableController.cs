using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Repositories;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VegetableController : ItemController<Vegetable>
    {
        public VegetableController(IItemRepository<Vegetable> itemRepository) : base(itemRepository)
        {
        }
    }
}
