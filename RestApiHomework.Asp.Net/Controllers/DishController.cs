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

    public class DishController : ControllerBase
    {
        private readonly DishService _dishService;

        public DishController(DishService dishService)
        {
            _dishService = dishService;
        }
        [HttpGet]
        public List<Dish> Get()
        {
            return _dishService.GetAll();
        }

        [HttpGet("{id}")]
        public Dish Get(int id)
        {
            return _dishService.Get(id);
        }

        [HttpPost]
        public void Post(Dish dish)
        {
            _dishService.AddItem(dish);
        }

        [HttpPut]
        public void Put(Dish dish)
        {
            _dishService.UpdateItem(dish);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dishService.DeleteItem(id);
        }
    }
}

