using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.Models;
using RestApiHomework.Asp.Net.Services;
using System.Collections.Generic;

namespace RestApiHomework.Asp.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VegetableController : ControllerBase
    {
        private readonly VegetableService _vegetableService;

        public VegetableController(VegetableService vegetableService)
        {
            _vegetableService = vegetableService;
        }
        [HttpGet]
        public List<Vegetable> Get()
        {
            return _vegetableService.GetAll();
        }

        [HttpGet("{id}")]
        public Vegetable Get(int id)
        {
            return _vegetableService.Get(id);
        }

        [HttpPost]
        public void Post(Vegetable item)
        {
            _vegetableService.AddItem(item);
        }

        [HttpPut]
        public void Put(Vegetable item)
        {
            _vegetableService.UpdateItem(item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vegetableService.DeleteItem(id);
        }
    }
}
