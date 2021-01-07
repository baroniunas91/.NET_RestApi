using Microsoft.EntityFrameworkCore;
using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;

namespace RestApiHomework.Asp.Net.Services
{
    public interface IItemService<T> where T : Item
    {
        DbContext Context { get; set; }
        T Get(int id);

        List<T> GetAll();

        void AddItem(T item);

        void DeleteItem(int id);

        void UpdateItem(T t);
    }
}