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
    public class EmployerController : Controller
    {
        private readonly AppDbContext _context;
        public EmployerController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            if (!_context.Employers.Any(x => x.Id == id))
            {
                return RedirectToAction("index", "home");
            }
            EmployerDetailViewModel employerDetailViewModel = new EmployerDetailViewModel
            {
                Employer = _context.Employers.Include(x => x.City).Include(x => x.EmployerImages).Include(x => x.Category).FirstOrDefault(x => x.Id == id),
                Jobs = _context.Jobs.Include(x=>x.JobCategory).Include(x=>x.JobImages).Include(x=>x.City).Include(x => x.Employer).Where(x => x.EmployerId == id).ToList()

            };
            return View(employerDetailViewModel);
        }
    }
}
