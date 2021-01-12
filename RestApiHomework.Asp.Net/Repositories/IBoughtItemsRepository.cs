using Microsoft.AspNetCore.Mvc;
using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;

namespace RestApiHomework.Asp.Net.Repositories
{
    public interface IBoughtItemsRepository<T> where T : Item
    {
        void BuyItem(T item, int id, int qty);
        List<BoughtItem> GetBoughtItems();
    }
}
