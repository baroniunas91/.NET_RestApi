using RestApiHomework.Asp.Net.Models;
using System.Collections.Generic;

namespace RestApiHomework.Asp.Net.Repositories
{
    public interface IBoughtItemsRepository
    {
        void BuyItem(BoughtItem item);
        List<BoughtItem> GetBoughtItems();
    }
}
