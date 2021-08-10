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
    public class JobController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public JobController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Jobs.Count() / 6m);
            List<Job> jobs = _context.Jobs.Include(x=>x.JobImages).Include(x=>x.JobCategory).Include(x=>x.RequiredLanguages).Skip((page-1)*6).Take(6).ToList();
            return View(jobs);
        }
        public IActionResult Create()
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.JobCategories.ToList();
            ViewBag.Employers = _context.Employers.ToList();
            ViewBag.Languages = _context.Languages.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Job job)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.JobCategories.ToList();
            ViewBag.Employers = _context.Employers.ToList();
            ViewBag.Languages = _context.Languages.ToList();
            if (!ModelState.IsValid) return View();

            return RedirectToAction("index");
        }
    }
}
