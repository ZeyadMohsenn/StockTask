using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class StoreItemRepo : IStoreItemRepo
    {
        private readonly StockContext _context;

        public StoreItemRepo(StockContext context)
        {
            _context = context;
        }

        public List<Item> GetAllItemsInStore(int storeId)
        {
            var itemsInStore = _context.Items
                .Include(i => i.StoreItems)
                    .ThenInclude(si => si.Store)
                .Where(i => i.StoreItems.Any(si => si.StoreId == storeId))
                .ToList();

            return itemsInStore;
        }

        public List<Item> GetAllAvailableItems()
        {
            return _context.Items.ToList();
        }
        public void AddItemToStore(StoreItem storeItem)
        {
            var existingStoreItem = _context.StoresItems
                .FirstOrDefault(si => si.StoreId == storeItem.StoreId && si.ItemId == storeItem.ItemId);

            if (existingStoreItem != null)
            {
                existingStoreItem.Quantity += storeItem.Quantity;
            }
            else
            {
                _context.StoresItems.Add(storeItem);
            }

            _context.SaveChanges();
        }
        public List<StoreItem> GetStoreItemsByItemId(int itemId)
        {
            return _context.StoresItems
                .Where(si => si.ItemId == itemId)
                .ToList();
        }

    }
}
