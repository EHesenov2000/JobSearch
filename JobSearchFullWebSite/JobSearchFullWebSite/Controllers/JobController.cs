using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using JobSearchFullWebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Controllers
{
    public class JobController : Controller
    {
        private readonly AppDbContext _context;
        public JobController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search, Job job, int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Jobs.ToList().Count() / 9m);
            JobIndexViewModel jobVM = new JobIndexViewModel
            {
                Jobs = _context.Jobs.Include(x => x.JobImages).Include(x => x.JobCategory).Include(X => X.City).ToList(),
                Cities = _context.Cities.ToList(),
                JobCategories = _context.JobCategories.ToList(),

            };
            if (search != null)
            {
                jobVM.Jobs = jobVM.Jobs.Where(x => x.Name.Contains(search)).ToList();
            }

            if (job.City != null)
            {
                if (job.City.Id != 0)
                {
                    City city = _context.Cities.FirstOrDefault(x => x.Id == job.City.Id);
                    jobVM.Jobs = jobVM.Jobs.Where(x => x.City.CityName == city.CityName).ToList();
                }
            }
            if (job.JobCategory != null)
            {
                if (job.JobCategory.Id != 0)
                {
                    JobCategory jobCategory = _context.JobCategories.FirstOrDefault(x => x.Id == job.JobCategory.Id);
                    jobVM.Jobs = jobVM.Jobs.Where(x => x.JobCategory.Name == jobCategory.Name).ToList();
                }
            }
            jobVM.Jobs = jobVM.Jobs.Skip((page - 1) * 9).Take(9).ToList();
            return View(jobVM);
        }
        public IActionResult Detail(int id)
        
        {
            if (!_context.Jobs.Any(x => x.Id == id))
            {
                return RedirectToAction("index", "home");
            }

            Job existjob = _context.Jobs.Include(x=>x.Employer).FirstOrDefault(x => x.Id == id);

            JobDetailViewModel JobVM = new JobDetailViewModel
            {
                Job = _context.Jobs.Include(x => x.JobCategory).Include(x => x.JobImages).Include(x => x.City).Include(x => x.Employer).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == id),
                EmployerImage = _context.EmployerImages.FirstOrDefault(x => x.IsPoster),
                RelatedJobs = _context.Jobs.Include(x=>x.JobImages).Include(x => x.JobCategory).Include(x => x.City).Where(x => x.Employer.Name == existjob.Employer.Name).ToList(),
            };
            

            return View(JobVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetContact(JobContact jobContact,int id)
        {
            jobContact.JobId = id;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Sehv askarlandi");
                return RedirectToAction("detail","job",id);
            }
            _context.JobContacts.Add(jobContact);
            _context.SaveChanges();
            return RedirectToAction("index","job");
        }
    }
}
