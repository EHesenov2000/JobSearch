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
    public class JobCategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public JobCategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.JobCategories.Count() / 6m);

            return View(_context.JobCategories.Include(x => x.Jobs).ToList()); ;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobCategory jobCategory)
        {
            if (!ModelState.IsValid) return View(jobCategory);
            _context.JobCategories.Add(jobCategory);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            JobCategory existJobCategory = _context.JobCategories.Include(x=>x.Jobs).FirstOrDefault(x => x.Id == id);
            if (existJobCategory == null) return View(existJobCategory);

            return View(existJobCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, JobCategory jobCategory)
        {
            JobCategory existJobCategory = _context.JobCategories.Include(x => x.Jobs).FirstOrDefault(x => x.Id == id);
            if (existJobCategory == null) return View(existJobCategory);
            existJobCategory.Name = jobCategory.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            JobCategory existJobCategory = _context.JobCategories.Include(x => x.Jobs).FirstOrDefault(x => x.Id == id);
            if (existJobCategory == null) return View(existJobCategory);
            _context.JobCategories.Remove(existJobCategory);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
