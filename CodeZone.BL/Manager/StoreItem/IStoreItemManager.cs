using CodeZone.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.BL
{
    public interface IStoreItemManager
    {
        List<Item> GetAllItemsInStore(int storeId);
        void AddItemToStore(AddItemToStoreViewModel storeItem);
        List<Item> GetAllAvailableItems();
        List<StoreActivityLog> GetStoreActivityLog(int storeId);
        void UpdateItemQuantity(int itemId, int storeId, int change);
        void DeleteLog(StoreActivityLog log);
        StoreActivityLog GetStoreActivityLogById(int logId);




    }
}
