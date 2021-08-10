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
    public class JobController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public JobController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Jobs.Count() / 6m);
            List<Job> jobs = _context.Jobs.Include(x=>x.JobImages).Include(x=>x.JobCategory).Include(x=>x.RequiredLanguages).Skip((page-1)*6).Take(6).ToList();
            return View(jobs);
        }
        public IActionResult Create()
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.JobCategories.ToList();
            ViewBag.Employers = _context.Employers.ToList();
            ViewBag.Languages = _context.Languages.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Job job)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.JobCategories.ToList();
            ViewBag.Employers = _context.Employers.ToList();
            ViewBag.Languages = _context.Languages.ToList();
            if (!ModelState.IsValid) return View();
            job.CreatedAt = DateTime.UtcNow.AddHours(4);
            _context.Jobs.Add(job);
            _context.SaveChanges();
            if (job.File != null)
            {
                if (job.File.ContentType != "image/png" && job.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (job.File.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("File", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + job.File.FileName;
                var path = Path.Combine(rootPath, "images/jobImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    job.File.CopyTo(stream);
                }
                JobImage jobImage = new JobImage
                {
                    Image = fileName,
                    IsPoster = true,
                    JobId = job.Id,
                };
                _context.JobImages.Add(jobImage);
            }
            if (job.Images != null)
            {
                foreach (var item in job.Images)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("File", "Jpeg ve ya png formatinda file daxil edilmelidir");
                        return View();
                    }
                    if (item.Length > (1024 * 1024) * 5)
                    {
                        ModelState.AddModelError("File", "File olcusu 5mb-dan cox olmaz!");
                        return View();
                    }
                    string rootPath = _env.WebRootPath;
                    var fileName = Guid.NewGuid().ToString() + item.FileName;
                    var path = Path.Combine(rootPath, "images/jobImage", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    JobImage jobImage = new JobImage
                    {
                        Image = fileName,
                        IsPoster = false,
                        JobId = job.Id,

                    };
                    _context.JobImages.Add(jobImage);
                }
            }
            if (job.RequiredLanguageIds != null)
            {
                foreach (var item in job.RequiredLanguageIds)
                {
                    if (_context.Languages.FirstOrDefault(x => x.Id == item) != null)
                    {
                        JobRequiredLanguage jobRequiredLanguage = new JobRequiredLanguage
                        {
                            Language = _context.Languages.FirstOrDefault(x => x.Id == item).Name,
                            JobId = job.Id
                        };
                        _context.JobRequiredLanguages.Add(jobRequiredLanguage);
                    }
                }
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int jobId)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.JobCategories.ToList();
            ViewBag.Employers = _context.Employers.ToList();
            ViewBag.Languages = _context.Languages.ToList();
            Job existJob = _context.Jobs.Include(x=>x.JobCategory).Include(x=>x.Employer).Include(x=>x.RequiredLanguages).Include(x=>x.City).Include(x=>x.JobImages).FirstOrDefault(x => x.Id == jobId);
            if (existJob == null) return RedirectToAction("index");
 
            return View(existJob);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int jobId,Job editJob)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.JobCategories.ToList();
            ViewBag.Employers = _context.Employers.ToList();
            ViewBag.Languages = _context.Languages.ToList();
            Job existJob = _context.Jobs.Include(x => x.JobCategory).Include(x => x.Employer).Include(x => x.RequiredLanguages).Include(x => x.City).Include(x => x.JobImages).FirstOrDefault(x => x.Id == jobId);
            if (existJob == null) return RedirectToAction("index");
            if (editJob.File!=null)
            {
                if (editJob.File.ContentType != "image/png" && editJob.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (editJob.File.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("File", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + editJob.File.FileName;
                var path = Path.Combine(rootPath, "images/jobImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    editJob.File.CopyTo(stream);
                }
                if (existJob.JobImages.FirstOrDefault(x => x.IsPoster) != null)
                {
                    if (existJob.JobImages.FirstOrDefault(x => x.IsPoster).Image != null)
                    {
                        existJob.JobImages.FirstOrDefault(x => x.IsPoster).Image = fileName;

                    }
                }
                else
                {
                    JobImage jobImage = new JobImage
                    {
                        Image = fileName,
                        IsPoster = true,
                        JobId = jobId,
                    };
                    _context.JobImages.Add(jobImage);
                }
            }
            if (editJob.Images != null)
            {
                foreach (var item in editJob.Images)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("File", "Jpeg ve ya png formatinda file daxil edilmelidir");
                        return View();
                    }
                    if (item.Length > (1024 * 1024) * 5)
                    {
                        ModelState.AddModelError("File", "File olcusu 5mb-dan cox olmaz!");
                        return View();
                    }
                    string rootPath = _env.WebRootPath;
                    var fileName = Guid.NewGuid().ToString() + item.FileName;
                    var path = Path.Combine(rootPath, "images/jobImage", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    JobImage jobImage = new JobImage
                    {
                        Image = fileName,
                        IsPoster = false,
                        JobId = jobId,

                    };
                    _context.JobImages.Add(jobImage);
                }
            }
            if (existJob.JobImages != null)
            {
                foreach (var item in existJob.JobImages)
                {
                    if (editJob.ImageIds != null)
                    {
                        if (!editJob.ImageIds.Contains(item.Id) && item.Id != 0)
                        {
                            //if (item.IsPoster == false)
                            //{
                            string rootPath = _env.WebRootPath;
                            var fileName = item.Image;
                            var path = Path.Combine(rootPath, "images/jobImage", fileName);
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }
                            _context.JobImages.Remove(item);
                            //}
                        }
                    }
                    else
                    {
                        if (editJob.Images == null)
                        {
                            string rootPath = _env.WebRootPath;
                            var fileName = item.Image;
                            var path = Path.Combine(rootPath, "images/jobImage", fileName);
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }
                            _context.JobImages.Remove(item);
                        }

                    }
                }
            }
            if (existJob.RequiredLanguages != null)
            {
                foreach (var item in existJob.RequiredLanguages)
                {
                    _context.JobRequiredLanguages.Remove(item);
                }
            }
            foreach (var item in editJob.RequiredLanguageIds)
            {
                if (_context.Languages.FirstOrDefault(x => x.Id == item) != null)
                {
                    JobRequiredLanguage jobRequiredLanguage = new JobRequiredLanguage
                    {
                        Language = _context.Languages.FirstOrDefault(x => x.Id == item).Name,
                        JobId = jobId
                    };
                    _context.JobRequiredLanguages.Add(jobRequiredLanguage);
                }
            }
            existJob.CreatedAt = DateTime.UtcNow.AddHours(4);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult DeleteJob(int jobId)
        {
            Job job = _context.Jobs.FirstOrDefault(x => x.Id == jobId);
            if (job == null) return RedirectToAction("index");
            _context.Jobs.Remove(job);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
