using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("customerror", "The name cannot be exactly same as Display Order");
            }
            if (ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["sucess"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        //GET
        public IActionResult Edit(int? id)
        {
            if( id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirstOrDefault = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingleOrDefault = _db.Categories.SingleOrDefault(u => u.Id == id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("customerror", "The name cannot be exactly same as Display Order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["sucess"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirstOrDefault = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingleOrDefault = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            var catobj = _db.Categories.Find(obj.Id);
            if (catobj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(catobj);
            _db.SaveChanges();
            TempData["sucess"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
