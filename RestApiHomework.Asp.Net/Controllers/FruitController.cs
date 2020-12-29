using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Services;
using System.Collections.Generic;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FruitController : ControllerBase
    {
        private readonly FruitService _fruitService;

        public FruitController(FruitService fruitService)
        {
            _fruitService = fruitService;
        }
        [HttpGet]
        public List<Fruit> Get()
        {
            return _fruitService.GetAll();
        }

        [HttpGet("{id}")]
        public Fruit Get(int id)
        {
            return _fruitService.Get(id);
        }

        [HttpPost]
        public void Post(Fruit fruit)
        {
            _fruitService.AddItem(fruit);
        }

        [HttpPut]
        public void Put(Fruit fruit)
        {
            _fruitService.UpdateItem(fruit);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _fruitService.DeleteItem(id);
        }
    }
}

