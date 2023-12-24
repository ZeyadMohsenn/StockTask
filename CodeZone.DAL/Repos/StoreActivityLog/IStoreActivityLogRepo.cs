using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public interface IStoreActivityLogRepo : IGenaricRepo<StoreActivityLog>
    {
        List<StoreActivityLog> GetStoreActivityLog(int storeId);
        public void DeleteLog(StoreActivityLog log);


    }
}
