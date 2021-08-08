using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.DTOs;
using JobSearchFullWebSite.Enums;
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
        public IActionResult Index(string search,Employer employer, int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Employers.ToList().Count() / 9m);
            EmployerIndexViewModel employerVM = new EmployerIndexViewModel
            {
                Employers = _context.Employers.Include(x => x.EmployerImages).Include(X => X.City).Include(X => X.Category).Include(x => x.Jobs).ToList(),
                Cities=_context.Cities.ToList(),
                Categories=_context.Categories.ToList(),
            };
            if (search!=null)
            {
                employerVM.Employers = employerVM.Employers.Where(x => x.Name.Contains(search)).ToList();
            }
  
            if (employer.City!=null)
            {
                if (employer.City.Id!=0)
                {
                    City city = _context.Cities.FirstOrDefault(x => x.Id == employer.City.Id);
                    employerVM.Employers = employerVM.Employers.Where(x => x.City.CityName == city.CityName).ToList();
                }
            }
            if (employer.Category!=null)
            {
                if (employer.Category.Id!=0)
                {
                    Category category = _context.Categories.FirstOrDefault(x => x.Id == employer.Category.Id);
                    employerVM.Employers = employerVM.Employers.Where(x => x.Category.Name == category.Name).ToList();
                }
            }
            employerVM.Employers = employerVM.Employers.Skip((page - 1) * 9).Take(9).ToList();

            return View(employerVM);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeStatus(int id,ApplyStatus  status)
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
        public IActionResult EmployerDashboard(int id)
        {
            Employer employer = _context.Employers.Include(x=>x.Followers).Include(x=>x.AppUser).ThenInclude(x=>x.Applies).Include(x=>x.EmployerContacts).Include(x=>x.Jobs).FirstOrDefault(x => x.Id == id);
            if (employer == null) return RedirectToAction("index");
            return View(employer);
        }
        public IActionResult EmployerProileEdit(int id)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            Employer existEmployer = _context.Employers.Include(x => x.EmployerImages).FirstOrDefault(x => x.Id == id);
            if (existEmployer == null) return RedirectToAction("index");
            EmployerEditDto employerEditDto = new EmployerEditDto();
            employerEditDto.Id = existEmployer.Id;
            employerEditDto.Name = existEmployer.Name;
            employerEditDto.FoundedDate = existEmployer.FoundedDate;
            employerEditDto.IsFeatured = false;
            employerEditDto.CreatedAt = existEmployer.CreatedAt;
            employerEditDto.PhoneNumber = existEmployer.PhoneNumber;
            employerEditDto.Email = existEmployer.Email;
            employerEditDto.FacebookUrl = existEmployer.FacebookUrl;
            employerEditDto.InstagramUrl = existEmployer.InstagramUrl;
            employerEditDto.LinkedinUrl = existEmployer.LinkedinUrl;
            employerEditDto.TwitterUrl = existEmployer.TwitterUrl;
            employerEditDto.CompanyContent = existEmployer.CompanyContent;
            employerEditDto.Website=existEmployer.Website;
            if (existEmployer.Category != null)
            {
                employerEditDto.CategoryId = existEmployer.Category.Id;
            }
            else
            {
                employerEditDto.CategoryId = 0;
            }
            if (existEmployer.City != null)
            {
                employerEditDto.CityId = existEmployer.City.Id;
            }
            else
            {
                employerEditDto.CityId = 0;
            }
            if (existEmployer.EmployerImages.Count() != 0)
            {
                employerEditDto.EmployerImages = existEmployer.EmployerImages;
                if (existEmployer.EmployerImages.FirstOrDefault(x => x.IsPoster)!=null)
                {
                    employerEditDto.PosterImage = existEmployer.EmployerImages.FirstOrDefault(x => x.IsPoster).Image;

                }
                else
                {
                    employerEditDto.PosterImage = "";
                }
            }
            else
            {
                employerEditDto.PosterImage = "";
            }
            return View(employerEditDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmployerProileEdit(int id,EmployerEditDto employerEditDto)
        {
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            Employer existEmployer = _context.Employers.Include(x => x.EmployerImages).FirstOrDefault(x => x.Id == id);
            if (existEmployer == null) return RedirectToAction("index");

            return View();
        }
    }
}
