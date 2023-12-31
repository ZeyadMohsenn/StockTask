﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockContext _context;

        public IStoreRepo Store { get; }
        public IItemRepo Item { get; }
        public IStoreItemRepo StoreItem { get; }
        public IStoreActivityLogRepo StoreActivityLogRepo { get; }

        public UnitOfWork(StockContext context, IStoreRepo storeRepo, IItemRepo itemRepo, IStoreItemRepo storeItemRepo,IStoreActivityLogRepo storeActivityLogRepo)
        {
            _context = context;
            Store = storeRepo;
            Item = itemRepo;
            StoreItem = storeItemRepo;
            StoreActivityLogRepo = storeActivityLogRepo;

        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
