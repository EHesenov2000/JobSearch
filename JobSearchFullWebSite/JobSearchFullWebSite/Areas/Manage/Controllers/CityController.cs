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
    public class CityController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CityController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Cities.Count() / 6m);

            return View(_context.Cities.Include(x => x.Jobs).Include(x => x.Employers).Skip((page-1)*6).Take(6).ToList()); ;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {
            if((city.Image==null && city.File == null)|| city.Latitude==null || city.Longitude==null)
            {
                ModelState.AddModelError("", "Sekil ve ya kordinatlarin her birini daxil etmelisiz");

                return View(city);
            }
            if (city.File != null)
            {
                if (city.File.ContentType != "image/png" && city.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Mime type yanlisdir!");
                    return View();
                }

                if (city.File.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("File", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + city.File.FileName;
                var path = Path.Combine(rootPath, "images/cityImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    city.File.CopyTo(stream);
                }
                city.Image = fileName;
                _context.Cities.Add(city);

            }

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            if (!_context.Cities.Any(x => x.Id == id)) return RedirectToAction("index");
            return View(_context.Cities.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,City city)
        {
            if (!_context.Cities.Any(x => x.Id == id)) return RedirectToAction("index");

            City existCity = _context.Cities.FirstOrDefault(x => x.Id == id);
            if (existCity == null) return RedirectToAction("index");





            if (city.File != null)
            {
                if (city.File.ContentType != "image/png" && city.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Mime type yanlisdir!");
                    return View(city);
                }
                if (city.File.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("File", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View(city);
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + city.File.FileName;
                var path = Path.Combine(rootPath, "images/cityImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    city.File.CopyTo(stream);
                }
                if (existCity.Image != null)
                {

                    var existPath = Path.Combine(rootPath, "images/cityImage", existCity.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                    existCity.Image = fileName;

                }
            }


            existCity.CityName = city.CityName;
            existCity.Latitude = city.Latitude;
            existCity.Longitude = city.Longitude;





            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            if (!_context.Cities.Any(x => x.Id == id)) return RedirectToAction("index");
            _context.Cities.Remove(_context.Cities.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
