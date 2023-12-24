using CodeZone.BL;
using CodeZone.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CodeZone.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoreManager _storeManager;
        private readonly IStoreItemManager _storeItemManager;
        public StoresController(IStoreManager storeManager, IStoreItemManager itemManager)
        {
            _storeManager = storeManager;
            _storeItemManager = itemManager;
        }
        public IActionResult Index()
        {
            List<Store> stores = _storeManager.GetStores();
            return View(stores);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(AddStoreDto storeDto)
        {
            if (ModelState.IsValid)
            {
                _storeManager.AddStore(storeDto);
                return RedirectToAction("Index");

            }
            return View(storeDto);

        }
        public IActionResult Details(int id)
        {
            Store store = _storeManager.GetStore(id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }
        public IActionResult Edit(int id)
        {
            Store store = _storeManager.GetStore(id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Store store)
        {
            if (id != store.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                _storeManager.UpdateStore(store, id);
                return RedirectToAction("Index");
            }

            return View(store);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Store store = _storeManager.GetStore(id);

            var isDeleted = _storeManager.DeleteStore(store);

            if (isDeleted)
            {
                return Ok(new { message = "Store deleted successfully" });
            }
            else
            {
                return BadRequest(new { message = "Failed to delete store" });
            }
        }
        public IActionResult ItemsInStore(int storeId)
        {
            List<Item> itemsInStore = _storeItemManager.GetAllItemsInStore(storeId);
            ViewBag.StoreId = storeId;

            return View(itemsInStore);
        }
        [HttpGet]
        public IActionResult AddItemToStore(int storeId)
        {
            var viewModel = new AddItemToStoreViewModel
            {
                StoreId = storeId,
                AvailableItems = _storeItemManager.GetAllAvailableItems()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddItemToStore(AddItemToStoreViewModel storeItem)
        {
            if (ModelState.IsValid)
            {
                _storeItemManager.AddItemToStore(storeItem);
                return RedirectToAction("ItemsInStore", new { storeId = storeItem.StoreId });
            }

            storeItem.AvailableItems = _storeItemManager.GetAllAvailableItems();
            return View(storeItem);
        }
        public IActionResult HistoryLog(int storeId)
        {
            var storeActivityLog = _storeItemManager.GetStoreActivityLog(storeId);
            ViewBag.StoreId = storeId;

            return View(storeActivityLog);
        }


        [HttpPost]
        public IActionResult DeleteLog(int logId, int storeId)
        {
            var log = _storeItemManager.GetStoreActivityLogById(logId);

            if (log != null)
            {
                _storeItemManager.DeleteLog(log);
            }

            return RedirectToAction("HistoryLog", new { storeId });
        }

    }
}