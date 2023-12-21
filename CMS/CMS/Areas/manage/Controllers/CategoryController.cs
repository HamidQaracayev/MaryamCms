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
            }
            _context.categories.Add(category);
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
