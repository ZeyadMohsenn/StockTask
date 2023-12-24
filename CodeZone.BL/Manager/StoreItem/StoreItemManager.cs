using CodeZone.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.BL
{
    public class StoreItemManager : IStoreItemManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public StoreItemManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Item> GetAllItemsInStore(int storeId)
        {
            List<Item> items = _unitOfWork.StoreItem.GetAllItemsInStore(storeId);
            return items;
        }
        public void AddItemToStore(AddItemToStoreViewModel storeItem)
        {
            StoreItem dbStoreItem = new StoreItem
            {
                StoreId = storeItem.StoreId,
                ItemId = storeItem.ItemId,
                Quantity = storeItem.Quantity
            };
            _unitOfWork.StoreItem.AddItemToStore(dbStoreItem);
            _unitOfWork.SaveChanges();

        }
        public List<Item> GetAllAvailableItems()
        {
            return _unitOfWork.StoreItem.GetAllAvailableItems();
        }



    }
}
