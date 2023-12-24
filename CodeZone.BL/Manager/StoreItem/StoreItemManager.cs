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
            LogStoreActivity(dbStoreItem.StoreId, dbStoreItem.ItemId, dbStoreItem.Quantity);


        }
        private void LogStoreActivity(int storeId, int itemId, int quantity)
        {
            var activityLog = new StoreActivityLog
            {
                StoreId = storeId,
                ItemId = itemId,
                Quantity = quantity,
                Timestamp = DateTime.UtcNow
            };

            _unitOfWork.StoreActivityLogRepo.Add(activityLog);
            _unitOfWork.SaveChanges();
        }

        public List<Item> GetAllAvailableItems()
        {
            return _unitOfWork.StoreItem.GetAllAvailableItems();
        }

        public List<StoreActivityLog> GetStoreActivityLog(int storeId)
        {
            return _unitOfWork.StoreActivityLogRepo.GetStoreActivityLog(storeId);
        }
        public void UpdateItemQuantity(int itemId, int storeId, int change)
        {
            _unitOfWork.StoreItem.UpdateQuantity(itemId, storeId, change);
        }
        public void DeleteLog(StoreActivityLog log)
        {
            _unitOfWork.StoreItem.UpdateQuantity(log.ItemId, log.StoreId, -log.Quantity);

            _unitOfWork.StoreActivityLogRepo.DeleteLog(log);

            _unitOfWork.SaveChanges();


        }
        public StoreActivityLog GetStoreActivityLogById(int logId)
        {
            return _unitOfWork.StoreActivityLogRepo.GetById(logId);
        }
    }
}
