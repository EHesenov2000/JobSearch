using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BlogItemRequirementController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogItemRequirementController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int id,int page=1)
        {
            ViewBag.BlogId = id;
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.BlogItemRequirements.Count() / 6m);
            return View(_context.BlogItemRequirements.Where(x=>x.BlogItemId==id).Skip((page-1)*6).Take(6).ToList());
        }
        public IActionResult Create(int id)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == id);
            if (blogItem == null) return RedirectToAction("index", id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id,BlogItemRequirement blogItemRequirement)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == id);
            if (blogItem == null) return RedirectToAction("index",id);
            if (!ModelState.IsValid) return View(blogItemRequirement);
            blogItemRequirement.BlogItemId = blogItem.Id;
            _context.BlogItemRequirements.Add(blogItemRequirement);
            _context.SaveChanges();
            return RedirectToAction("index",id);
        }
        public IActionResult Edit(int blogItemId,int id)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == blogItemId);
            if (blogItem == null) return RedirectToAction("index", blogItemId);
            BlogItemRequirement ıtemRequirement = _context.BlogItemRequirements.FirstOrDefault(x => x.Id == id && x.BlogItemId==blogItemId);
            if (ıtemRequirement == null) return RedirectToAction("index", blogItemId);
            return View(ıtemRequirement);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int blogItemId,int id,BlogItemRequirement blogItemRequirement)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == blogItemId);
            if (blogItem == null) return RedirectToAction("index", blogItemId);
            if (!ModelState.IsValid) return View(blogItemRequirement);
            BlogItemRequirement ıtemRequirement = _context.BlogItemRequirements.FirstOrDefault(x => x.Id == id);
            if (ıtemRequirement == null) return RedirectToAction("index", blogItemId);
            ıtemRequirement.Requirement = blogItemRequirement.Requirement;
            _context.SaveChanges();
            return RedirectToAction("index", blogItemId);
        }
        public IActionResult Delete(int blogItemId, int id)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == blogItemId);
            if (blogItem == null) return RedirectToAction("index", blogItemId);
            BlogItemRequirement ıtemRequirement = _context.BlogItemRequirements.FirstOrDefault(x => x.Id == id);
            if(ıtemRequirement==null) return RedirectToAction("index", blogItemId);
            _context.BlogItemRequirements.Remove(ıtemRequirement);
            _context.SaveChanges();
            return RedirectToAction("index", blogItemId);
        }
    }
}
