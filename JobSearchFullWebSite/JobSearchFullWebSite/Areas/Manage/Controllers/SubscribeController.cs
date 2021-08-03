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
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SubscribeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Subscribes.Count() / 6m);
            return View(_context.Subscribes.Skip((page - 1) * 6).Take(6).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subscribe subscribe)
        {
            if (!ModelState.IsValid) return View(subscribe);
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Edit(int id)
        {
            Subscribe existSubscribe = _context.Subscribes.FirstOrDefault(x => x.Id == id);
            if (existSubscribe == null) return RedirectToAction("index");

            return View(existSubscribe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Subscribe subscribe)
        {
            Subscribe existSubscribe = _context.Subscribes.FirstOrDefault(x => x.Id == id);
            if (existSubscribe == null) return RedirectToAction("index");
            existSubscribe.Email = existSubscribe.Email;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Subscribe existSubscribe = _context.Subscribes.FirstOrDefault(x => x.Id == id);
            if (existSubscribe == null) return RedirectToAction("index");
            _context.Subscribes.Remove(existSubscribe);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
