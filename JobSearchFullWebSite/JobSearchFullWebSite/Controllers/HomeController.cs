using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel HomeVm = new HomeViewModel
            {
                HowWorks = _context.HowWorks.ToList(),
                Jobs = _context.Jobs.Include(x=>x.JobImages).Include(x=>x.Employer).ThenInclude(x=>x.Category).Include(x=>x.City).Where(x => x.IsFeatured).ToList(),
                Cities=_context.Cities.Include(x=>x.Jobs).Take(5).ToList(),
                Candidates=_context.Candidates.Include(x=>x.CandidateImages).Include(x=>x.City).Where(x=>x.IsFeatured).ToList(),
                BlogItems = _context.BlogItems.OrderBy(x=>x.CreatedAt).Take(3).ToList()
            };
            return View(HomeVm);
        }
            
    }
}
