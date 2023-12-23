using CodeZone.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.BL
{
    public class ItemManager : IItemManager
    {
        private IUnitOfWork _unitOfWork;

        public ItemManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddItem(AddItemDto? item)
        {
            Item dbItem = new Item
            {
                ItemName = item.Name,
                price = item.price,
                Quantity = item.Quantity

            };
            _unitOfWork.Item.Add(dbItem);
            _unitOfWork.SaveChanges();
        }
        public Item GetItem(int id)
        {
            Item? item = _unitOfWork.Item.GetById(id);
            if (item == null) { return null!; }
            return item;
        }
        public List<Item> GetItems()
        {
            List<Item> items = _unitOfWork.Item.GetAll();
            return items;
        }
        public bool DeleteItem(Item item)
        {
            try
            {
                _unitOfWork.Item.Delete(item);
                var affectedRows = _unitOfWork.SaveChanges();

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Item UpdateItem(UpdateItemDto item, int id)
        {
            Item? dbItem = _unitOfWork.Item.GetById(id);
            if (dbItem != null)
            {
                dbItem.price = item.price;
                dbItem.Quantity = item.Quantity;
                dbItem.ItemName = item.Name;


                _unitOfWork.Item.Update(dbItem);
                _unitOfWork.SaveChanges();
            }
            return dbItem;

        }
    }
}
