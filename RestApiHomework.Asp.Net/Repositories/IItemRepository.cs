using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;
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
