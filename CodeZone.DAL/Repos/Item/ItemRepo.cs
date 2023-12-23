using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class ItemRepo : GenaricRepo<Item>, IItemRepo
    {

        public ItemRepo(StockContext context) : base(context)
        {
        }
        public void AddItem(Item item)
        {
            Add(item);
            SaveChanges();

        }
        public void UpdateItem(Item item)
        {
            Update(item);
            SaveChanges();

        }
        public void DeleteItem(Item item)
        {
            Delete(item);
            SaveChanges();

        }
        public List<Item> GetAllItems()
        {
           return GetAll();
        }
        public Item? GetItemById(int id)
        {
            return GetById(id);
        }
    }
}
