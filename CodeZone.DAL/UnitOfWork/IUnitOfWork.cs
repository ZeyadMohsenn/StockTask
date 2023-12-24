using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public interface IUnitOfWork
    {
        public IStoreRepo Store { get; }
        public IItemRepo Item { get; }
        public IStoreItemRepo StoreItem { get; }
        public IStoreActivityLogRepo StoreActivityLogRepo { get; }

        int SaveChanges();

    }
}
