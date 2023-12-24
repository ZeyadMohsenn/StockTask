using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class StoreActivityLogRepo : GenaricRepo<StoreActivityLog>, IStoreActivityLogRepo
    {
        private readonly StockContext _context;

        public StoreActivityLogRepo(StockContext context) : base(context)
        {
            _context = context;

        }
        public List<StoreActivityLog> GetStoreActivityLog(int storeId)
        {
            return _context.StoreActivityLogs
                .Where(log => log.StoreId == storeId)
                .OrderByDescending(log => log.Timestamp)
                .Include(log => log.Item) 
                .ToList();
        }
        public void DeleteLog(StoreActivityLog log)
        {
            _context.StoreActivityLogs.Remove(log);
            _context.SaveChanges();
        }
    }
}
