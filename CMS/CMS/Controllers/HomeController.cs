using CMS.DAL;
using CMS.Models;
using CMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            UserViewModel model = new UserViewModel();
            model.Users = _context.users.ToList();
            model.Categories = _context.categories.ToList();
            return View(model);
        }

        public IActionResult User()
        {
            UserViewModel model = new UserViewModel();
            model.Users = _context.users.ToList();
            model.Categories = _context.categories.ToList();
            return View(model);
        }

        public IActionResult Content() 
        {
            UserViewModel model = new UserViewModel();
            model.Users = _context.users.ToList();
            model.Categories = _context.categories.ToList();
            return View(model);
        }
        public IActionResult Category()
        {

            UserViewModel model = new UserViewModel();
            model.Users = _context.users.ToList();
            model.Categories = _context.categories.ToList();
            return View(model);
        }
    }
}
