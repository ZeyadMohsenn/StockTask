using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class StoreRepo : GenaricRepo<Store> , IStoreRepo
    {

        public StoreRepo(StockContext context) : base(context)
        {
        }
        public void AddStore(Store store)
        {
            Add(store);
            SaveChanges();

        }
        public void UpdateStore(Store store)
        { 
            Update(store);
            SaveChanges();

        }
        public void DeleteStore(Store store)
        {
            Delete(store);
            SaveChanges();
        }
        public List<Store> GetAllStores()
        {
            return GetAll();
        }
        public Store? GetStoreById(int id)
        {
            return GetById(id);
        }
    }
}
