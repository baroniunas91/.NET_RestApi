using Microsoft.EntityFrameworkCore;
using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiHomework.Asp.Net.Services
{
    public class ItemService<T> : IItemService<T> where T : Item
    {
        public DbContext Context { get; set; }
        public async Task<List<T>> GetAll()
        {
            var items = await Context.Set<T>().OrderBy(x => x.Id).ToListAsync();
            return items;
        }

        public async Task<T> Get(int id)
        {
            var item = await Context.Set<T>().Where(i => i.Id == id).SingleOrDefaultAsync();
            return item;
        }

        public async Task AddItem(T item)
        {
            Context.Set<T>().Add(item);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateItem(T item)
        {
            foreach (var value in Context.Set<T>())
            {
                if (value.Id == item.Id)
                {
                    value.Name = item.Name;
                }
            }
            await Context.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var item = Context.Set<T>().Where(i => i.Id == id).SingleOrDefault();
            Context.Set<T>().Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}

