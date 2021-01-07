using Microsoft.EntityFrameworkCore;
using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApiHomework.Asp.Net.Services
{
    public class ItemService<T> : IItemService<T> where T : Item
    {
        public DbContext Context { get; set; }
        public List<T> GetAll()
        {
            var items = Context.Set<T>().OrderBy(x => x.Id).ToList();
            return items;
        }

        public T Get(int id)
        {
            var item = Context.Set<T>().Where(i => i.Id == id).SingleOrDefault();
            return item;
        }

        public void AddItem(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }

        public void UpdateItem(T item)
        {
            foreach (var value in Context.Set<T>())
            {
                if (value.Id == item.Id)
                {
                    value.Name = item.Name;
                }
            }
            Context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var item = Context.Set<T>().Where(i => i.Id == id).SingleOrDefault();
            Context.Set<T>().Remove(item);
            Context.SaveChanges();
        }
    }
}

