using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApiHomework.Asp.Net.Services
{
    public class FruitService
    {
        private List<Fruit> Fruits = new List<Fruit>();
        public int number { get; set; } = 0;

        public List<Fruit> GetAll()
        {
            return Fruits;
        }

        public Fruit Get(int id)
        {
            Fruit requestedFruit = null;
            foreach (var fruit in Fruits)
            {
                if (fruit.Id == id)
                {
                    requestedFruit = fruit;
                }
            }
            return requestedFruit;
        }

        public void AddItem(Fruit fruit)
        {
            number += 1;
            fruit.Id = number;
            Fruits.Add(fruit);
        }

        public void UpdateItem(Fruit fruit)
        {
            foreach (var value in Fruits)
            {
                if (value.Id == fruit.Id)
                {
                    value.Name = fruit.Name;
                }
            }
        }

        public void DeleteItem(int id)
        {
            Fruits = Fruits.Where(i => i.Id != id).ToList();
        }
    }
}
