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
    public class BlogItemLearnController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogItemLearnController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int id,int page=1)
        {
            ViewBag.BlogId = id;
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.BlogItemLearns.Count() / 6m);
            return View(_context.BlogItemLearns.Where(x=>x.BlogItemId==id).Skip((page-1)*6).Take(6).ToList());
        }
        public IActionResult Create(int id)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == id);
            if (blogItem == null) return RedirectToAction("index", id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id,BlogItemLearn blogItemLearn)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == id);
            if (blogItem == null) return RedirectToAction("index",id);
            if (!ModelState.IsValid) return View(blogItemLearn);
            blogItemLearn.BlogItemId = blogItem.Id;
            _context.BlogItemLearns.Add(blogItemLearn);
            _context.SaveChanges();
            return RedirectToAction("index",id);
        }
        public IActionResult Edit(int blogItemId,int id)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == blogItemId);
            if (blogItem == null) return RedirectToAction("index", blogItemId);
            BlogItemLearn ıtemLearn = _context.BlogItemLearns.FirstOrDefault(x => x.Id == id && x.BlogItemId==blogItemId);
            if (ıtemLearn == null) return RedirectToAction("index", blogItemId);
            return View(ıtemLearn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int blogItemId,int id,BlogItemLearn blogItemLearn)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == blogItemId);
            if (blogItem == null) return RedirectToAction("index", blogItemId);
            if (!ModelState.IsValid) return View(blogItemLearn);
            BlogItemLearn ıtemLearn = _context.BlogItemLearns.FirstOrDefault(x => x.Id == id);
            if (ıtemLearn == null) return RedirectToAction("index", blogItemId);
            ıtemLearn.Learn = blogItemLearn.Learn;
            _context.SaveChanges();
            return RedirectToAction("index", blogItemId);
        }
        public IActionResult Delete(int blogItemId, int id)
        {
            BlogItem blogItem = _context.BlogItems.FirstOrDefault(x => x.Id == blogItemId);
            if (blogItem == null) return RedirectToAction("index", blogItemId);
            BlogItemLearn ıtemLearn = _context.BlogItemLearns.FirstOrDefault(x => x.Id == id);
            if(ıtemLearn == null) return RedirectToAction("index", blogItemId);
            _context.BlogItemLearns.Remove(ıtemLearn);
            _context.SaveChanges();
            return RedirectToAction("index", blogItemId);
        }
    }
}
