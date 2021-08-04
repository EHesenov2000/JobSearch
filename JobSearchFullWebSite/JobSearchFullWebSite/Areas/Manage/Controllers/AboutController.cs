using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            About about = _context.Abouts.Include(x=>x.AboutImages).First(); 
            return View(about);
        }
        //public IActionResult Create()
        //{
        //    //bir eded yaradilibsa artiq editlene bilsin
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(About about)
        //{
        //    if(!ModelState.IsValid) { return View(); }
        //    //if((_context.AboutImages.Where(x=>x.Id==about.Id ).Count()+about.AboutTopImage.Count())>6)
        //    if (about.AboutTopImage.Count() != 0)
        //    {
        //        foreach (var item in about.AboutTopImage)
        //        {
        //            if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
        //            {
        //                ModelState.AddModelError("AboutTopImage", "Mime type yanlisdir!");
        //                return View();
        //            }
        //            if (item.Length > (1024 * 1024) * 5)
        //            {
        //                ModelState.AddModelError("AboutTopImage", "File olcusu 5mb-dan cox olmaz!");
        //                return View();
        //            }

        //            string rootPath = _env.WebRootPath;
        //            var fileName = Guid.NewGuid().ToString() + item.FileName;
        //            var path = Path.Combine(rootPath, "images/aboutImage", fileName);
        //            using (FileStream stream = new FileStream(path, FileMode.Create))
        //            {
        //                item.CopyTo(stream);
        //            }
        //            AboutImage aboutImage = new AboutImage
        //            {
        //                About = about,
        //                Image = fileName
        //            };
        //            _context.AboutImages.Add(aboutImage);

        //        }
        //    }
        //    _context.Abouts.Add(about);
        //    _context.SaveChanges();     
        //    return View();
        //}
        public IActionResult Edit(int id)
        {
            About existBook = _context.Abouts.Include(x=>x.AboutImages).FirstOrDefault(x => x.Id == id);
            if (existBook == null) return RedirectToAction("index");
            return View(existBook);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,About about)
        {
            About existAbout = _context.Abouts.Include(x=>x.AboutImages).FirstOrDefault(x => x.Id == id);
            if (existAbout == null) return RedirectToAction("index");
            if (!ModelState.IsValid) return RedirectToAction("index");

            existAbout.ActiveUsers = about.ActiveUsers;
            existAbout.Positions = about.Positions;
            existAbout.Shared = about.Shared;
            existAbout.AboutContentTextEditor = about.AboutContentTextEditor;

            if (about.AboutTopImage != null)
            {
                foreach (var item in about.AboutTopImage)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("AboutTopImage", "Mime type yanlisdir!");
                        return View(about);
                    }

                    if (item.Length > (1024 * 1024) * 5)
                    {
                        ModelState.AddModelError("AboutTopImage", "Faly olcusu 5MB-dan cox ola bilmez!");
                        return View(about);
                    }
                    string rootPath = _env.WebRootPath;
                    var fileName = Guid.NewGuid().ToString() + item.FileName;
                    var path = Path.Combine(rootPath, "images/aboutImage", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    AboutImage aboutImage = new AboutImage
                    {
                        AboutId = existAbout.Id,
                        Image = fileName
                    };
                    _context.AboutImages.Add(aboutImage);

                }
            }
            List<AboutImage> existAboutImages = _context.AboutImages.Where(x => x.AboutId == about.Id).ToList();
            if (existAboutImages != null)
            {
                foreach (var item in existAboutImages)
                {
                    if (about.AboutTopImageId != null)
                    {
                        if (!about.AboutTopImageId.Contains(item.Id))
                        {
                            _context.AboutImages.Remove(item);
                            string rootPath = _env.WebRootPath;

                            var path = Path.Combine(rootPath, "images/aboutImage", item.Image);
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }

                        }
                    }
                    else
                    {
                        if(about.AboutTopImage==null){
                            _context.AboutImages.Remove(item);
                            string rootPath = _env.WebRootPath;

                            var path = Path.Combine(rootPath, "images/aboutImage", item.Image);
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }
                        }
                    }
                }
            }

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        //public IActionResult Delete(int id)
        //{
        //    if (_context.Abouts.Any(x => x.Id == id))
        //    {
        //        _context.Abouts.Remove(_context.Abouts.FirstOrDefault(x => x.Id == id));
        //    }
        //    if (_context.AboutImages.Any(x => x.AboutId == id))
        //    {
        //        foreach (var item in _context.AboutImages.Where(x => x.AboutId == id).ToList())
        //        {
        //            _context.AboutImages.Remove(item); 
        //        }
        //    }
        //    _context.SaveChanges();
        //    return View();
        //}
        //sekili de papkadan silmeyi elave edecem bu hisseni acasi olsam
    }
}
