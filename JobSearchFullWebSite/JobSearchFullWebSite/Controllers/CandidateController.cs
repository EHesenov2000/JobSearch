using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Controllers
{
    public class CandidateController : Controller
    {
        private readonly AppDbContext _context;
        public CandidateController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            if (!_context.Candidates.Any(x => x.Id == id))
            {
                return RedirectToAction("index", "home");
            }
            Candidate candidate = _context.Candidates.Include(x => x.City).Include(x => x.CandidateSkills).Include(x => x.CandidateImages).Include(x => x.KnowingLanguages).Include(x => x.CandidateCVs).Include(x => x.CandidateAwardItems).Include(x => x.CandidateEducationItems).Include(x => x.CandidateWorkItems).FirstOrDefault(x=>x.Id==id);
            return View(candidate);
        }
    }
}
