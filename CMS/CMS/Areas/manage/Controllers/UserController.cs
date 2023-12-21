﻿using CMS.DAL;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Areas.manage.Controllers
{
    [Area("Manage")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _context.categories.ToList();
            ViewBag.Content = _context.content.ToList();
            List<User> users = _context.users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.categories.ToList();
            ViewBag.Content = _context.content.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            ViewBag.Categories = _context.categories.ToList();
            ViewBag.Content = _context.content.ToList();
            //if (!ModelState.IsValid) { return View(); }

            if(!_context.categories.Any(x => x.Id == user.CategoryId)) 
            {
                ModelState.AddModelError("CategoryId", "Category Not Found");
                return View();
            }
            _context.users.Add(user);
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
            User user = _context.users.FirstOrDefault(b => b.Id == id);

            if (user == null) return NotFound();
            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(User user)
        {
            ViewBag.Categories = _context.categories.ToList();
            ViewBag.Content = _context.content.ToList();



            User existsUser = _context.users.FirstOrDefault(b => b.Id == user.Id);

            if (existsUser == null) return NotFound();

            _context.users.Remove(existsUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
