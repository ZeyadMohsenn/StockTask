﻿using CodeZone.DAL;
using System.Collections.Generic;

namespace CodeZone.BL
{
    public interface IItemManager
    {
        void AddItem(AddItemDto? item);
        Item GetItem(int id);
        List<Item> GetItems();
        bool DeleteItem(Item item);
        Item UpdateItem(Item item, int id);
        int CalculateTotalQuantity(int itemId);

    }
}
