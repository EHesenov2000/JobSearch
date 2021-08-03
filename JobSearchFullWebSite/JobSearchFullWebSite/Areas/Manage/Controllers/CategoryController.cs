using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage=Math.Ceiling(_context.Categories.Count()/6m);
            return View(_context.Categories.Include(x=>x.Employers).Skip((page-1)*6).Take(6).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Edit(int id)
        {
            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (existCategory == null) return RedirectToAction("index");

            return View(existCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Category category)
        {
            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (existCategory == null) return RedirectToAction("index");
            if (category == null) return RedirectToAction("index");
            existCategory.Name = category.Name;
            _context.SaveChanges();
            return View();
        }
        public IActionResult Delete(int id)
        {
            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (existCategory == null) return RedirectToAction("index");
            _context.Categories.Remove(_context.Categories.FirstOrDefault(x=>x.Id==id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
