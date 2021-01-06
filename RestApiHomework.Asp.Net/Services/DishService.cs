using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApiHomework.Asp.Net.Services
{
    public class DishService
    {
        public DishService(MainContext context)
        {
            _context = context;
        }
        //private List<Dish> Dishes = new List<Dish>();
        private readonly MainContext _context;

        public List<Dish> GetAll()
        {
            var dishes = _context.Dishes.OrderBy(x => x.Id).ToList();
            return dishes;
        }

        public Dish Get(int id)
        {
            var dish = _context.Dishes.Where(i => i.Id == id).SingleOrDefault();
            return dish;
        }

        public void AddItem(Dish dish)
        {
            _context.Dishes.Add(dish);
            _context.SaveChanges();
        }

        public void UpdateItem(Dish dish)
        {
            foreach (var value in _context.Dishes)
            {
                if (value.Id == dish.Id)
                {
                    value.Name = dish.Name;
                }
            }
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var dish = _context.Dishes.Where(i => i.Id == id).SingleOrDefault();
            _context.Dishes.Remove(dish);
            _context.SaveChanges();
        }
    }
}

