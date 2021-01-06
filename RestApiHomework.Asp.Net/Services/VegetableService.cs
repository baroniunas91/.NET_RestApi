using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApiHomework.Asp.Net.Services
{
    public class VegetableService
    {
        private readonly MainContext _context;

        public VegetableService(MainContext context)
        {
            _context = context;
        }
        public List<Vegetable> GetAll()
        {
            var vegetables = _context.Vegetables.OrderBy(x => x.Id).ToList();
            return vegetables;
        }

        public Vegetable Get(int id)
        {
            var vegetable = _context.Vegetables.Where(i => i.Id == id).SingleOrDefault();
            return vegetable;
        }

        public void AddItem(Vegetable vegetable)
        {
            _context.Vegetables.Add(vegetable);
            _context.SaveChanges();
        }

        public void UpdateItem(Vegetable vegetable)
        {
            foreach (var value in _context.Vegetables)
            {
                if (value.Id == vegetable.Id)
                {
                    value.Name = vegetable.Name;
                }
            }
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var vegetable = _context.Vegetables.Where(i => i.Id == id).SingleOrDefault();
            _context.Vegetables.Remove(vegetable);
            _context.SaveChanges();
        }
    }
}
