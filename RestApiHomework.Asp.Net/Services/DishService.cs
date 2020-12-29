using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApiHomework.Asp.Net.Services
{
    public class DishService
    {
        private List<Dish> Dishes = new List<Dish>();
        public int number { get; set; } = 0;

        public List<Dish> GetAll()
        {
            return Dishes;
        }

        public Dish Get(int id)
        {
            Dish requestedDish = null;
            foreach (var dish in Dishes)
            {
                if (dish.Id == id)
                {
                    requestedDish = dish;
                }
            }
            return requestedDish;
        }

        public void AddItem(Dish dish)
        {
            number += 1;
            dish.Id = number;
            Dishes.Add(dish);
        }

        public void UpdateItem(Dish dish)
        {
            foreach (var value in Dishes)
            {
                if (value.Id == dish.Id)
                {
                    value.Name = dish.Name;
                }
            }
        }

        public void DeleteItem(int id)
        {
            Dishes = Dishes.Where(i => i.Id != id).ToList();
        }
    }
}

