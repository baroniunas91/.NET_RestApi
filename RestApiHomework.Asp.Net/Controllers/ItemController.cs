using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public abstract class ItemController<T> : ControllerBase where T : Item
    {
        private readonly IItemService<T> _itemService;

        public ItemController(IItemService<T> itemService, MainContext context)
        {
            _itemService = itemService;
            _itemService.Context = context;
        }
        [HttpGet]
        public async Task<List<T>> Get()
        {
            return await _itemService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<T> Get(int id)
        {
            return await _itemService.Get(id);
        }

        [HttpPost]
        public async Task Post(T item)
        {
            await _itemService.AddItem(item);
        }

        [HttpPut]
        public async Task Put(T item)
        {
            await _itemService.UpdateItem(item);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _itemService.DeleteItem(id);
        }
    }
}

