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
    public class EmployerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EmployerController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Employers.Count()/6m);
            List<Employer> employers = _context.Employers.Include(x => x.EmployerImages).Include(x=>x.Category).Include(x=>x.City).Include(x=>x.Jobs).Include(x=>x.Followers).Skip((page-1)*6).Take(6).ToList();
            return View(employers);
        }
        public IActionResult Create()
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employer employer)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int employerId)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            Employer existEmployer = _context.Employers.Include(x=>x.Category).Include(x=>x.City).Include(x=>x.EmployerImages).Include(x=>x.Jobs).Include(x=>x.Followers).FirstOrDefault(x => x.Id == employerId);
            if(existEmployer == null) return RedirectToAction("index");
            return View(existEmployer);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int employerId, Employer employer)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            Employer existEmployer = _context.Employers.Include(x => x.Category).Include(x => x.City).Include(x => x.EmployerImages).Include(x => x.Jobs).Include(x => x.Followers).FirstOrDefault(x => x.Id == employerId);
            if (existEmployer == null) return RedirectToAction("index");
            return RedirectToAction("index");
        }
        public IActionResult Delete(int employerId)
        {
            Employer existEmployer = _context.Employers.Include(x => x.Category).Include(x => x.City).Include(x => x.EmployerImages).Include(x => x.Jobs).Include(x => x.Followers).FirstOrDefault(x => x.Id == employerId);
            if (existEmployer == null) return RedirectToAction("index");
            return RedirectToAction("index");
        }
    }
}
