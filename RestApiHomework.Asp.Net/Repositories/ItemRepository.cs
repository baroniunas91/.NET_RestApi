using Microsoft.EntityFrameworkCore;
using RestApiHomework.Asp.Net.data;
using RestApiHomework.Asp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiHomework.Asp.Net.Repositories
{
    public class ItemRepository<T> : IItemRepository<T> where T : Item
    {
        private readonly MainContext _context;
        public ItemRepository(MainContext context)
        {
            _context = context;
        }
        public DbContext Context { get; set; }
        public async Task<List<T>> GetAll()
        {
            var items = await _context.Set<T>().OrderBy(x => x.Id).ToListAsync();
            return items;
        }

        public async Task<T> Get(int id)
        {
            var item = await _context.Set<T>().Where(i => i.Id == id).SingleOrDefaultAsync();
            return item;
        }

        public async Task AddItem(T item)
        {
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(T item)
        {
            foreach (var value in _context.Set<T>())
            {
                if (value.Id == item.Id)
                {
                    value.Name = item.Name;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var item = _context.Set<T>().Where(i => i.Id == id).SingleOrDefault();
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
