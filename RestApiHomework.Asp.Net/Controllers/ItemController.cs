using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public abstract class ItemController<T> : ControllerBase where T : Item
    {
        private readonly IItemRepository<T> _itemRepository;

        public ItemController(IItemRepository<T> itemRepository)
        {
            _itemRepository = itemRepository;
        }
        [HttpGet]
        public async Task<List<T>> Get()
        {
            return await _itemRepository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<T> Get(int id)
        {
            return await _itemRepository.Get(id);
        }
        [HttpPost]
        public async Task Post(T item)
        {
            await _itemRepository.AddItem(item);
        }
        [HttpPut]
        public async Task Put(T item)
        {
            await _itemRepository.UpdateItem(item);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _itemRepository.DeleteItem(id);
        }
    }
}

