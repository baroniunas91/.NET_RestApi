using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApiHomework.Asp.Net.Services
{
    public class VegetableService
    {
        private List<Vegetable> Vegetables = new List<Vegetable>();
        public int number { get; set; } = 0;

        public List<Vegetable> GetAll()
        {
            return Vegetables;
        }

        public Vegetable Get(int id)
        {
            Vegetable requestedVegetable = null;
            foreach (var vegetable in Vegetables)
            {
                if(vegetable.Id == id)
                {
                    requestedVegetable = vegetable;
                }
            }
            return requestedVegetable;
        }

        public void AddItem(Vegetable vegetable)
        {
            number += 1;
            vegetable.Id = number;
            Vegetables.Add(vegetable);
        }

        public void UpdateItem(Vegetable vegetable)
        {
            foreach (var value in Vegetables)
            {
                if (value.Id == vegetable.Id)
                {
                    value.Name = vegetable.Name;
                }
            }
        }

        public void DeleteItem(int id)
        {
            Vegetables = Vegetables.Where(i => i.Id != id).ToList();
        }
    }
}
