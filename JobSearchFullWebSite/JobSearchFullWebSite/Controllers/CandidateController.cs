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
    public class CandidateController : Controller
    {
        private readonly AppDbContext _context;
        public CandidateController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search, Candidate candidate, int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Candidates.ToList().Count() / 9m);
            CandidateIndexViewModel candidateVM = new CandidateIndexViewModel
            {
                Candidates = _context.Candidates.Include(x => x.CandidateImages).Include(x=>x.CandidateSkills).Include(X => X.City).Include(X => X.Position).ToList(),
                Cities = _context.Cities.ToList(),
                Positions = _context.Positions.ToList(),

            };
            if (search != null)
            {
                candidateVM.Candidates = candidateVM.Candidates.Where(x => x.FullName.Contains(search)).ToList();
            }

            if (candidate.City != null)
            {
                if (candidate.City.Id != 0)
                {
                    City city = _context.Cities.FirstOrDefault(x => x.Id == candidate.City.Id);
                    candidateVM.Candidates = candidateVM.Candidates.Where(x => x.City.CityName == city.CityName).ToList();
                }
            }
            if (candidate.Position != null)
            {
                if (candidate.Position.Id != 0)
                {
                    Position position = _context.Positions.FirstOrDefault(x => x.Id == candidate.Position.Id);
                    candidateVM.Candidates = candidateVM.Candidates.Where(x => x.Position.PositionName == position.PositionName).ToList();
                }
            }
            candidateVM.Candidates = candidateVM.Candidates.Skip((page - 1) * 9).Take(9).ToList();
            return View(candidateVM);
        }
        public IActionResult Detail(int id)
        {
            if (!_context.Candidates.Any(x => x.Id == id))
            {
                return RedirectToAction("index", "home");
            }
            Candidate candidate = _context.Candidates.Include(x=>x.Position).Include(x => x.City).Include(x => x.CandidateSkills).Include(x => x.CandidateImages).Include(x => x.KnowingLanguages).Include(x => x.CandidateCVs).Include(x => x.CandidateAwardItems).Include(x => x.CandidateEducationItems).Include(x => x.CandidateWorkItems).FirstOrDefault(x=>x.Id==id);
            return View(candidate);
        }
        public IActionResult CandidateCabinet()
        {
            AppUser user = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (_context.Candidates.Any(x=>x.AppUserId==user.Id))
            {
                //bura edit sehifesidi
            }
            else
            {
                //bura create sehifesidi
            }
            return null;
        }
    }
}
