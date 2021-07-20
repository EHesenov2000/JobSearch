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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutViewModel aboutVM = new AboutViewModel
            {
                HowWorks = _context.HowWorks.ToList(),
                Testimonials = _context.Testimonials.ToList(),
                AboutSponsors = _context.AboutSponsors.ToList(),
                About=_context.Abouts.Include(x=>x.AboutImages).First()
            };
            return View(aboutVM);
        }
        public IActionResult FAQ()
        {
            List<FAQ> Faqs = _context.FAQs.ToList();
            return View(Faqs);
        }
        public IActionResult Terms()
        {
            return View(_context.Terms.First());
        }
    }
}
