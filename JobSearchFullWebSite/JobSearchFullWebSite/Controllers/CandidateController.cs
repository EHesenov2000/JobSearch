using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.DTOs;
using JobSearchFullWebSite.Enums;
using JobSearchFullWebSite.Models;
using JobSearchFullWebSite.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;
        public CandidateController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
        public IActionResult CandidateDashboard()
        {
            return View();
        }
        public IActionResult CandidateApplieds()
        {
            return View();
        }
        public IActionResult CandidateShortList()
        {
            return View();
        }
        public IActionResult CandidateFollowings()
        {
            return View();
        }
        //public IActionResult CandidateAlerts()
        //{
        //    return View();
        //}
        public IActionResult CandidateProfileEdit(int id)
        {
            ViewBag.Languages =_context.Languages.ToList(); 
            ViewBag.Positions = _context.Positions.ToList();
            ViewBag.Cities = _context.Cities.ToList();
            //Candidate candidate = _context.Candidates.Include(x=>x.KnowingLanguages).FirstOrDefault(x => x.Id == id);
            //if (candidate == null)
            //{
            //    return RedirectToAction("index");
            //}
            //candidate
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CandidateProfileEdit(int id,CandidateEditDto candidateEditDto)
        {
            ViewBag.Languages = _context.Languages.ToList();
            ViewBag.Positions = _context.Positions.ToList();
            ViewBag.Cities = _context.Cities.ToList();
            Candidate existCandidate = _context.Candidates.Include(x=>x.CandidateImages).Include(x => x.KnowingLanguages).FirstOrDefault(x => x.Id == id);
            if (!_context.Cities.Any(x => x.Id == candidateEditDto.CityId)) return RedirectToAction("index");
            if (!_context.Positions.Any(x => x.Id == candidateEditDto.PositionId)) return RedirectToAction("index");
            if (existCandidate == null) return RedirectToAction("index");
            if (candidateEditDto.Image != null)
            {
                if (candidateEditDto.Image.ContentType != "image/png" && candidateEditDto.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("Image", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (candidateEditDto.Image.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("Image", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + candidateEditDto.Image.FileName;
                var path = Path.Combine(rootPath, "images/candidateImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    candidateEditDto.Image.CopyTo(stream);
                }
                if (existCandidate.CandidateImages.FirstOrDefault(x=>x.IsPoster).Image != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "images/candidateImage", existCandidate.CandidateImages.FirstOrDefault(x => x.IsPoster).Image);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existCandidate.CandidateImages.FirstOrDefault(x => x.IsPoster).Image = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            existCandidate.FullName = candidateEditDto.FullName;
            existCandidate.IsFeatured = false;
            existCandidate.WaitingSalary = candidateEditDto.WaitingSalary;
            existCandidate.SalaryForTime = candidateEditDto.SalaryForTime;
            existCandidate.BirthdayDate = candidateEditDto.BirthdayDate;
            existCandidate.CreatedAt = DateTime.UtcNow.AddHours(4);
            existCandidate.AboutCandidateTextEditor = candidateEditDto.AboutCandidateTextEditor;
            existCandidate.Experience = candidateEditDto.Experience;
            existCandidate.Gender = candidateEditDto.Gender;
            existCandidate.Age = candidateEditDto.Age;
            existCandidate.Qualification = candidateEditDto.Qualification;
            existCandidate.Email = candidateEditDto.Email;
            existCandidate.PhoneNumber = candidateEditDto.PhoneNumber;
            existCandidate.FacebookUrl = candidateEditDto.FacebookUrl;
            existCandidate.TwitterUrl = candidateEditDto.TwitterUrl;
            existCandidate.LinkedinUrl = candidateEditDto.LinkedinUrl;
            existCandidate.InstagramUrl = candidateEditDto.InstagramUrl;
            existCandidate.InstagramUrl = candidateEditDto.InstagramUrl;
            existCandidate.CityId = candidateEditDto.CityId;
            existCandidate.PositionId = candidateEditDto.PositionId;

            var existLanguages = _context.CandidateKnowingLanguages.Where(x => x.CandidateId == id).ToList();
            if (candidateEditDto.KnowingLanguageIds!=null)
            {
                foreach (var item in candidateEditDto.KnowingLanguageIds)
                {
                    var existLanguage = existLanguages.FirstOrDefault(x => x.Id == item);
                    if (existLanguage == null)
                    {
                        CandidateKnowingLanguage knowingLanguage = new CandidateKnowingLanguage
                        {
                            CandidateId = id,
                            LanguageId = item
                        };
                        _context.CandidateKnowingLanguages.Add(knowingLanguage);
                    }
                    else
                    {
                        existLanguages.Remove(existLanguage);
                    }   
                }
            }
            _context.CandidateKnowingLanguages.RemoveRange(existLanguages);

            _context.SaveChanges(); 
            return View();
        }
    }
}
