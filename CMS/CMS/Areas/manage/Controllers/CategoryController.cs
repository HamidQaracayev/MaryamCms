using CMS.DAL;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Areas.manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.categories.ToList();

            return View(categories);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //if(!ModelState.IsValid) { return View(); }

            if(_context.categories.Any(x=> x.Name == category.Name)) 
            {
                ModelState.AddModelError("Name", "There is Category with same name!");
                return View();
            }
            _context.categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var category = _context.categories.FirstOrDefault(x=> x.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            var existCategory =  _context.categories.FirstOrDefault(x => x.Id == category.Id);

            if (existCategory == null) return NotFound();

            if (_context.categories.Any(x => x.Name.ToLower() == category.Name.ToLower()/* && existCategory.Id != category.Id*/))
            {
                ModelState.AddModelError("Name", "Category has already created!");
                return View();
            }

            existCategory.Name = category.Name;

             _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Categories = _context.categories.ToList();
            ViewBag.Content = _context.content.ToList();

            if (id == null)
            {
                return NotFound();
            }
            Category category = _context.categories.FirstOrDefault(b => b.Id == id);

            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            ViewBag.Categories = _context.categories.ToList();
            ViewBag.Content = _context.content.ToList();



            Category existsCategory = _context.categories.FirstOrDefault(b => b.Id == category.Id);

            if (existsCategory == null) return NotFound();

            _context.categories.Remove(existsCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
