using Microsoft.EntityFrameworkCore;
using RestApiHomework.Asp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiHomework.Asp.Net.Repositories
{
    public interface IItemRepository<T> where T : Item
    {
        Task<T> Get(int id);

        Task<List<T>> GetAll();

        Task AddItem(T item);

        Task DeleteItem(int id);

        Task UpdateItem(T t);
    }
}
