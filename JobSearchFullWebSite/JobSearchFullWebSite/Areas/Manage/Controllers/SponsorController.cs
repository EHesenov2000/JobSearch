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
    public class SponsorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SponsorController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            
            return View(_context.AboutSponsors.ToList());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AboutSponsor sponsor)
        {
            if (_context.AboutSponsors.Count() == 6)
            {
                ModelState.AddModelError("", "Maksimum 6 sponsor elave ede bilersiz!");
                return View();
            }
            if (sponsor.SponsorImage == null && sponsor.AboutSponsorImage==null)
            {

                ModelState.AddModelError("AboutSponsorImage", "Sekil elave etmelisiz");
                return View(sponsor);
            }
            if (sponsor.AboutSponsorImage != null)
            {
                
                if (sponsor.AboutSponsorImage.ContentType != "image/png" && sponsor.AboutSponsorImage.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("AboutSponsorImage", "Mime type yanlisdir!");
                    return View();
                }

                if (sponsor.AboutSponsorImage.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("AboutSponsorImage", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + sponsor.AboutSponsorImage.FileName;
                var path = Path.Combine(rootPath, "images/sponsorImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    sponsor.AboutSponsorImage.CopyTo(stream);
                }

                AboutSponsor newSponsor = new AboutSponsor
                {
                    SponsorImage = fileName
                };
                sponsor.SponsorImage = fileName;
                _context.AboutSponsors.Add(newSponsor);
            }

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            return View(_context.AboutSponsors.FirstOrDefault(x=>x.Id==id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,AboutSponsor sponsor)
        {
            if (!_context.AboutSponsors.Any(x => x.Id == id)) return RedirectToAction("index");
            if(sponsor.AboutSponsorImage==null)
            {
                ModelState.AddModelError("AboutSponsorImage", "Yeni sekil elave etmelisiz");
                return View();
            }
            AboutSponsor existSponsor = _context.AboutSponsors.FirstOrDefault(x => x.Id == id);
            if(existSponsor==null) return RedirectToAction("index");


            if (sponsor.AboutSponsorImage.ContentType != "image/png" && sponsor.AboutSponsorImage.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("AboutTopImage", "Mime type yanlisdir!");
                return View(sponsor);
            }

            if (sponsor.AboutSponsorImage.Length > (1024 * 1024) * 5)
            {
                ModelState.AddModelError("AboutTopImage", "Faly olcusu 5MB-dan cox ola bilmez!");
                return View(sponsor);
            }
            string rootPath = _env.WebRootPath;
            var fileName = Guid.NewGuid().ToString() + sponsor.AboutSponsorImage.FileName;
            var path = Path.Combine(rootPath, "images/sponsorImage", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                sponsor.AboutSponsorImage.CopyTo(stream);
            }
            if (existSponsor.SponsorImage != null)
            {

                var existPath = Path.Combine(rootPath, "images/sponsorImage",existSponsor.SponsorImage);
                if (System.IO.File.Exists(existPath))
                {
                    System.IO.File.Delete(existPath);
                }
                existSponsor.SponsorImage = fileName;

            }
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            if (!_context.AboutSponsors.Any(x => x.Id == id)) return RedirectToAction("index");
            string rootPath = _env.WebRootPath;

            var path = Path.Combine(rootPath, "images/sponsorImage", _context.AboutSponsors.FirstOrDefault(x => x.Id == id).SponsorImage);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.AboutSponsors.Remove(_context.AboutSponsors.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
