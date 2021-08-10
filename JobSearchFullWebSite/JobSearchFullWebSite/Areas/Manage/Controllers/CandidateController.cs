using JobSearchFullWebSite.DAL.AppDbContext;
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
    public class CandidateController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CandidateController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Employers.Count() / 6m);
            List<Candidate> candidates = _context.Candidates.Include(x => x.CandidateImages).Include(x => x.Position).Include(x => x.City).Include(x => x.KnowingLanguages).Include(x => x.Followers).Include(x=>x.CandidateCVS).Skip((page - 1) * 6).Take(6).ToList();
            return View(candidates);
        }
        public IActionResult Create()
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Positions = _context.Positions.ToList();
            ViewBag.Language = _context.Languages.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Candidate candidate)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Positions = _context.Positions.ToList();
            ViewBag.Language = _context.Languages.ToList();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Positions = _context.Positions.ToList();
            ViewBag.Language = _context.Languages.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Candidate candidate)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Positions = _context.Positions.ToList();
            ViewBag.Language = _context.Languages.ToList();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            return RedirectToAction("index");
        }
    }
}
