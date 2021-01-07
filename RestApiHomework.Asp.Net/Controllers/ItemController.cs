using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Services;
using System.Collections.Generic;
using System.Linq;

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
        public List<T> Get()
        {
            return _itemService.GetAll();
        }

        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _itemService.Get(id);
        }

        [HttpPost]
        public void Post(T item)
        {
            _itemService.AddItem(item);
        }

        [HttpPut]
        public void Put(T item)
        {
            _itemService.UpdateItem(item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _itemService.DeleteItem(id);
        }
    }
}

