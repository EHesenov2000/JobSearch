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
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TestimonialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Testimonials.Count() / 6m);
            return View(_context.Testimonials.Skip((page - 1) * 6).Take(6).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Testimonial testimonial)
        {
            if(testimonial.Image==null && testimonial.TestimonialImage == null)
            {
                ModelState.AddModelError("", "Sekilin elave edilmesi zamani sehvlik bas verdi");
                return View(testimonial);
            }
            if (testimonial.TestimonialImage != null)
            {
                if (testimonial.TestimonialImage.ContentType != "image/png" && testimonial.TestimonialImage.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("TestimonialImage", "Mime type yanlisdir!");
                    return View();
                }

                if (testimonial.TestimonialImage.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("TestimonialImage", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + testimonial.TestimonialImage.FileName;
                var path = Path.Combine(rootPath, "images/testimonialImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    testimonial.TestimonialImage.CopyTo(stream);
                }
                testimonial.Image = fileName;
                 _context.Testimonials.Add(testimonial);
            }
            else
            {
                ModelState.AddModelError("TestimonialImage", "Sekil elave etmelisiniz");
                return View(testimonial);
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Testimonial testimonial = _context.Testimonials.FirstOrDefault(x => x.Id == id);
            if (testimonial == null) return RedirectToAction("index");
            return View(testimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Testimonial testimonial)
        {
            Testimonial existTestimonial = _context.Testimonials.FirstOrDefault(x => x.Id == id);
            if (testimonial == null) return RedirectToAction("index");
            if (testimonial.TestimonialImage != null)
            {
                if (testimonial.TestimonialImage.ContentType != "image/png" && testimonial.TestimonialImage.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("TestimonialImage", "Mime type yanlisdir!");
                    return View();
                }

                if (testimonial.TestimonialImage.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("TestimonialImage", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + testimonial.TestimonialImage.FileName;
                var path = Path.Combine(rootPath, "images/testimonialImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    testimonial.TestimonialImage.CopyTo(stream);
                }
                if (existTestimonial.Image != null)
                {
                    var existPath = Path.Combine(rootPath, "images/testimonialImage", existTestimonial.Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existTestimonial.Image = fileName;
            }
            existTestimonial.Name = testimonial.Name;
            existTestimonial.Position = testimonial.Position;
            existTestimonial.BlueText = testimonial.BlueText;
            existTestimonial.Content = testimonial.Content;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Testimonial testimonial = _context.Testimonials.FirstOrDefault(x => x.Id == id);
            if (testimonial == null) return RedirectToAction("index");

            string rootPath = _env.WebRootPath;
            var existPath = Path.Combine(rootPath, "images/testimonialImage",testimonial.Image);
            if (System.IO.File.Exists(existPath))
            {
                System.IO.File.Delete(existPath);
            }
            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
