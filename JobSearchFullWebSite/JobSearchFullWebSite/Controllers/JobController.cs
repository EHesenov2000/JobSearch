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
        public IActionResult Index()
        {
            return View();
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
