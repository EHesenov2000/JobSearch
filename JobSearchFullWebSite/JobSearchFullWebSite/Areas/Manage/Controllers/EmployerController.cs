using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.DTOs;
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
        public IActionResult Create(EmployerEditDto employer)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            Employer newEmployer = new Employer();


            newEmployer.Name = employer.Name;
            newEmployer.FoundedDate = employer.FoundedDate;
            newEmployer.IsFeatured = false;
            newEmployer.CreatedAt = DateTime.UtcNow.AddHours(4);
            newEmployer.PhoneNumber = employer.PhoneNumber;
            newEmployer.Email = employer.Email;
            newEmployer.FacebookUrl = employer.FacebookUrl;
            newEmployer.InstagramUrl = employer.InstagramUrl;
            newEmployer.LinkedinUrl = employer.LinkedinUrl;
            newEmployer.TwitterUrl = employer.TwitterUrl;
            newEmployer.CompanyContent = employer.CompanyContent;
            newEmployer.Website = employer.Website;
            newEmployer.CityId = employer.CityId;
            newEmployer.CategoryId = employer.CategoryId;

            _context.Employers.Add(newEmployer);
            _context.SaveChanges();


            if (employer.PosterImageFile != null)
            {
                if (employer.PosterImageFile.ContentType != "image/png" && employer.PosterImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (employer.PosterImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("PosterImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + employer.PosterImageFile.FileName;
                var path = Path.Combine(rootPath, "images/employerImage", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    employer.PosterImageFile.CopyTo(stream);
                }
                EmployerImage employerImage = new EmployerImage
                {
                    IsPoster = true,
                    Image = fileName,
                    EmployerId = newEmployer.Id,
                };
                _context.EmployerImages.Add(employerImage);
            }
            if (employer.Images != null)
            {
                foreach (var item in employer.Images)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("PosterImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                        return View();
                    }
                    if (item.Length > (1024 * 1024) * 5)
                    {
                        ModelState.AddModelError("PosterImageFile", "File olcusu 5mb-dan cox olmaz!");
                        return View();
                    }
                    string rootPath = _env.WebRootPath;
                    var fileName = Guid.NewGuid().ToString() + item.FileName;
                    var path = Path.Combine(rootPath, "images/employerImage", fileName);

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    EmployerImage employerImage = new EmployerImage
                    {
                        IsPoster = false,
                        Image = fileName,
                        EmployerId = newEmployer.Id,
                    };
                    _context.EmployerImages.Add(employerImage);
                }
            }
            _context.SaveChanges();
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
        public IActionResult Edit(int employerId, EmployerEditDto employer)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            Employer existEmployer = _context.Employers.Include(x => x.Category).Include(x => x.City).Include(x => x.EmployerImages).Include(x => x.Jobs).Include(x => x.Followers).FirstOrDefault(x => x.Id == employerId);
            if (existEmployer == null) return RedirectToAction("index");

            if (employer.PosterImageFile != null)
            {
                if (employer.PosterImageFile.ContentType != "image/png" && employer.PosterImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (employer.PosterImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("PosterImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + employer.PosterImageFile.FileName;
                var path = Path.Combine(rootPath, "images/employerImage", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    employer.PosterImageFile.CopyTo(stream);
                }

                _context.EmployerImages.FirstOrDefault(x => x.EmployerId == employerId && x.IsPoster).Image = fileName;
            }
            if (employer.PosterImage == null)
            {
                //candidateEditDto.Image = "";
                if (existEmployer.EmployerImages.Any(x => x.IsPoster))
                {
                    string rootPath = _env.WebRootPath;
                    var fileName = existEmployer.EmployerImages.FirstOrDefault(x => x.IsPoster).Image; ;
                    var path = Path.Combine(rootPath, "images/employerImage", fileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);

                    }
                    _context.EmployerImages.Remove(_context.EmployerImages.FirstOrDefault(x => x.EmployerId == existEmployer.Id && x.IsPoster));

                }

            }
            if (employer.Images != null)
            {
                foreach (var item in employer.Images)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("Images", "Mime type yanlisdir!");
                        return View(employer);
                    }

                    if (item.Length > (1024 * 1024) * 5)
                    {
                        ModelState.AddModelError("Images", "Faly olcusu 5MB-dan cox ola bilmez!");
                        return View(employer);
                    }

                    string rootPath = _env.WebRootPath;
                    var fileName = Guid.NewGuid().ToString() + item.FileName;
                    var path = Path.Combine(rootPath, "images/employerImage", fileName);

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    EmployerImage employerImage = new EmployerImage
                    {
                        Image = fileName,
                        IsPoster = false,
                        EmployerId = existEmployer.Id
                    };
                    _context.EmployerImages.Add(employerImage);
                }
            }
            if (existEmployer.EmployerImages != null)
            {
                foreach (var item in existEmployer.EmployerImages)
                {
                    if (employer.ImagesId != null)
                    {
                        if (!employer.ImagesId.Contains(item.Id) && item.Id != 0)
                        {
                            if (item.IsPoster == false)
                            {
                                string rootPath = _env.WebRootPath;
                                var fileName = item.Image;
                                var path = Path.Combine(rootPath, "images/employerImage", fileName);
                                if (System.IO.File.Exists(path))
                                {
                                    System.IO.File.Delete(path);
                                }
                                _context.EmployerImages.Remove(item);
                            }
                        }

                    }
                    else
                    {
                        if (employer.Images == null)
                        {
                            if (item.IsPoster == false)
                            {
                                string rootPath = _env.WebRootPath;
                                var fileName = item.Image;
                                var path = Path.Combine(rootPath, "images/employerImage", fileName);
                                if (System.IO.File.Exists(path))
                                {
                                    System.IO.File.Delete(path);
                                }
                                _context.EmployerImages.Remove(item);
                            }
                        }

                    }
                }
            }
            existEmployer.Name = employer.Name;
            existEmployer.FoundedDate = employer.FoundedDate;
            existEmployer.IsFeatured = false;
            existEmployer.CreatedAt = DateTime.UtcNow.AddHours(4);
            existEmployer.PhoneNumber = employer.PhoneNumber;
            existEmployer.Email = employer.Email;
            existEmployer.FacebookUrl = employer.FacebookUrl;
            existEmployer.InstagramUrl = employer.InstagramUrl;
            existEmployer.LinkedinUrl = employer.LinkedinUrl;
            existEmployer.TwitterUrl = employer.TwitterUrl;
            existEmployer.CompanyContent = employer.CompanyContent;
            existEmployer.Website = employer.Website;
            existEmployer.CityId = employer.CityId;
            existEmployer.CategoryId = employer.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int employerId)
        {
            Employer existEmployer = _context.Employers.Include(x => x.Category).Include(x => x.City).Include(x => x.EmployerImages).Include(x => x.Jobs).Include(x => x.Followers).FirstOrDefault(x => x.Id == employerId);
            if (existEmployer == null) return RedirectToAction("index");
            _context.Employers.Remove(existEmployer);//isdeleted false qoysam tek isdeletedi false edecem yox remove qalsa onda images-lerin de silmeliyem
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
