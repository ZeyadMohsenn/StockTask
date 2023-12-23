using CodeZone.DAL;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.BL
{
    public class StoreManager : IStoreManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public StoreManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddStore(AddStoreDto? storeDto) 
        {
            Store dbStore = new Store
            {
                Name = storeDto.Name,
            };
            _unitOfWork.Store.Add(dbStore);
            _unitOfWork.SaveChanges();
        }
        public Store GetStore(int id)
        {
            Store? store = _unitOfWork.Store.GetById(id);
            if (store == null) { return null!; }
            return store;
        }
        public List<Store> GetStores()
        {
            List<Store> stores = _unitOfWork.Store.GetAll();
            return stores;
        }
        public bool DeleteStore(Store store)
        {
            try
            {
                _unitOfWork.Store.Delete(store);
                var affectedRows = _unitOfWork.SaveChanges();

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Store UpdateStore(Store store, int id)
        {
            Store? dbStore = _unitOfWork.Store.GetById(id);
            if (dbStore != null) 
            {
                dbStore.Name = store.Name;
                dbStore.ManagerName = store.ManagerName;
                dbStore.ClosingTime = store.ClosingTime;
                dbStore.OpeningTime =store.OpeningTime;
                dbStore.PhoneNumber = store.PhoneNumber;
                _unitOfWork.Store.Update(dbStore);
                _unitOfWork.SaveChanges();
            }
            return dbStore;

        }
    }
}
