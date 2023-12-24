using CodeZone.BL;
using CodeZone.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeZone.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemManager _itemManager;

        public ItemsController(IItemManager itemManager)
        {
            _itemManager = itemManager;
        }

        public IActionResult Index()
        {
            List<Item> items = _itemManager.GetItems();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddItemDto itemDto)
        {
            if (ModelState.IsValid)
            {
                _itemManager.AddItem(itemDto);
                return RedirectToAction("Index");
            }

            return View(itemDto);
        }

        public IActionResult Details(int id)
        {
            Item item = _itemManager.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Quantity = _itemManager.CalculateTotalQuantity(item.Id);


            return View(item);
        }

        public IActionResult Edit(int id)
        {
            Item item = _itemManager.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _itemManager.UpdateItem(item, id);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Item item = _itemManager.GetItem(id);
            bool isDeleted = _itemManager.DeleteItem(item);

            if (isDeleted)
            {
                return Ok(new { message = "Item deleted successfully" });
            }
            else
            {
                return BadRequest(new { message = "Failed to delete Item" });
            }
        }
    }
}
