using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public interface IStoreItemRepo 
    {
        List<Item> GetAllItemsInStore(int storeId);
        List<Item> GetAllAvailableItems();
        void AddItemToStore(StoreItem storeItem);
        List<StoreItem> GetStoreItemsByItemId(int itemId);
        void UpdateQuantity(int itemId, int storeId, int change);



    }
}
