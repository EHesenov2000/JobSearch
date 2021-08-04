using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Enums;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ApplyController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ApplyController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Applies.Count() / 6m);

            var model = _context.Applies.Include(x => x.AppUser).ThenInclude(x=>x.Candidate).Include(x=>x.Job).ThenInclude(x=>x.Employer).OrderByDescending(x => x.RequestDate).Skip((page - 1) * 6).Take(6).ToList();
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            Apply apply = _context.Applies.Include(x => x.AppUser).ThenInclude(x => x.Candidate).Include(x => x.Job).ThenInclude(x=>x.Employer).FirstOrDefault(x => x.Id == id);

            if (apply == null)
            {
                return RedirectToAction("index");
            }

            return View(apply);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id, ApplyStatus status)
        {
            Apply apply = _context.Applies.FirstOrDefault(x => x.Id == id);

            if (apply == null)
            {
                return RedirectToAction("index");
            }

            apply.ApplyStatus = status;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
