using CodeZone.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.BL
{
    public interface IStoreManager
    {
        void AddStore(AddStoreDto? storeDto);
        Store GetStore(int id);
        List<Store> GetStores();
        bool DeleteStore(Store store);
        Store UpdateStore(Store store, int id);
    }
}
