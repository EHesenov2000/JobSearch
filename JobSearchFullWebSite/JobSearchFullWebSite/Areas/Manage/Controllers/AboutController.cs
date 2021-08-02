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
        public IActionResult Create()
        {
            //bir eded yaradilibsa artiq editlene bilsin
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(About about)
        {
            if(!ModelState.IsValid) { View(); }
            if (about.AboutTopImage.Count() != 0)
            {
                foreach (var item in about.AboutTopImage)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("AboutTopImage", "Mime type yanlisdir!");
                        return View();
                    }
                    if (item.Length > (1024 * 1024) * 5)
                    {
                        ModelState.AddModelError("AboutTopImage", "File olcusu 5mb-dan cox olmaz!");
                        return View();
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
                        About = about,
                        Image = fileName
                    };
                    _context.AboutImages.Add(aboutImage);

                }
            }
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        //public IActionResult Delete()
        //{
        //    return View();
        //}
    }
}
