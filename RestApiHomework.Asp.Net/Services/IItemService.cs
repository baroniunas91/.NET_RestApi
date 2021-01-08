using Microsoft.EntityFrameworkCore;
using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApiHomework.Asp.Net.Services
{
    public interface IItemService<T> where T : Item
    {
        DbContext Context { get; set; }
        Task<T> Get(int id);

        Task<List<T>> GetAll();

        Task AddItem(T item);

        Task DeleteItem(int id);

        Task UpdateItem(T t);
    }
}