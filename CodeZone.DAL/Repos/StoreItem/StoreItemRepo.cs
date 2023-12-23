using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class StoreItemRepo : GenaricRepo<StoreItem>, IStoreItemRepo
    {

        public StoreItemRepo(StockContext context) : base(context)
        {
        }
    }
}
