using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class HowWorkController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HowWorkController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.HowWorks.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HowWork howWork)
        {
            if (_context.HowWorks.Count() == 3)
            {
                ModelState.AddModelError("", "Maksimum 3 eded howwork elave ede bilersiz!");
                return View(howWork);
            }
            if (howWork.File != null)
            {
                if (howWork.File.ContentType != "image/png" && howWork.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Mime type yanlisdir!");
                    return View();
                }
                if (howWork.File.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("File", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }

                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + howWork.File.FileName;
                var path = Path.Combine(rootPath, "images/howworkImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    howWork.File.CopyTo(stream);
                }
                howWork.Image = fileName;
            }
            if (howWork.Image == null || howWork.Title == null || howWork.Content == null)
            {
                ModelState.AddModelError("","Forumu tam doldurun zehmet olmasa");
                return View(howWork);
            }
            _context.HowWorks.Add(howWork);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            HowWork existHowWork = _context.HowWorks.FirstOrDefault(x => x.Id == id);
            if (existHowWork == null) return RedirectToAction("index");
            return View(existHowWork);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,HowWork howWork)
        {
            HowWork existHowWork = _context.HowWorks.FirstOrDefault(x => x.Id == id);
            if (existHowWork == null) return RedirectToAction("index");
            if (howWork == null) return RedirectToAction("index");
            if (howWork.File != null)
            {
                if (howWork.File.ContentType != "image/png" && howWork.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Mime type yanlisdir!");
                    return View(howWork);
                }

                if (howWork.File.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("File", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View(howWork);
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + howWork.File.FileName;
                var path = Path.Combine(rootPath, "images/howworkImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    howWork.File.CopyTo(stream);
                }
                if (existHowWork.Image != null)
                {
                    var existFilename = existHowWork.Image;
                    var existPath = Path.Combine(rootPath, "images/howworkImage", existFilename);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }

                }
                existHowWork.Image = fileName;
            }
            existHowWork.Title = howWork.Title;
            existHowWork.Content = howWork.Content;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            HowWork existHowWork = _context.HowWorks.FirstOrDefault(x => x.Id == id);
            if (existHowWork == null) return RedirectToAction("index");
            _context.HowWorks.Remove(_context.HowWorks.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
