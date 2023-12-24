using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class StockContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<StoreItem> StoresItems { get; set; }
        public DbSet<StoreActivityLog> StoreActivityLogs { get; set; }
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
