using CodeZone.BL;
using CodeZone.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CodeZone.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoreManager _storeManager;
        public StoresController(IStoreManager storeManager)
        {
            _storeManager = storeManager;
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

        //    public IActionResult Delete(int id)
        //    {
        //        Store store = _storeManager.GetStore(id);
        //        if (store == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(store);
        //    }

        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult DeleteConfirmed(int id)
        //    {
        //        Store store = _storeManager.GetStore(id);
        //        if (store != null)
        //        {
        //            _storeManager.DeleteStore(store);
        //        }

        //        return RedirectToAction("Index");
        //    }
        //}


    }
}