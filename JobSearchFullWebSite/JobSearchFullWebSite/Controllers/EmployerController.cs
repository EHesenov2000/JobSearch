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
    public class EmployerController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;
        public EmployerController(AppDbContext context, IWebHostEnvironment env)
        {
            _env = env;
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
            if (employerEditDto.CityId != 0)
            {
                if (!_context.Cities.Any(x => x.Id == employerEditDto.CityId)) return RedirectToAction("index");
            }
            if (employerEditDto.CategoryId != 0)
            {
                if (!_context.Categories.Any(x => x.Id == employerEditDto.CategoryId)) return RedirectToAction("index");
            }
            if (employerEditDto.CompanyContent == null)
            {
                ModelState.AddModelError("CompanyContent", "Context daxil edilmelidir");
                return View();
            }
            if (employerEditDto.CompanyContent.Length > 1500)
            {
                ModelState.AddModelError("CompanyContent", "Maksimum uzunluq 1000-dir");
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View(employerEditDto);
            }
            if (employerEditDto.PosterImageFile != null)
            {
                if (employerEditDto.PosterImageFile.ContentType != "image/png" && employerEditDto.PosterImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (employerEditDto.PosterImageFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("PosterImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + employerEditDto.PosterImageFile.FileName;
                var path = Path.Combine(rootPath, "images/employerImage", fileName);




                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    employerEditDto.PosterImageFile.CopyTo(stream);
                }
                if (existEmployer.EmployerImages.Count != 0)
                {
                    if (existEmployer.EmployerImages.FirstOrDefault(x => x.IsPoster)!=null)
                    {
                        if (existEmployer.EmployerImages.FirstOrDefault(x => x.IsPoster).Image != null)
                        {
                            string existPath = Path.Combine(_env.WebRootPath, "images/employerImage", existEmployer.EmployerImages.FirstOrDefault(x => x.IsPoster).Image);
                            if (System.IO.File.Exists(existPath))
                            {
                                System.IO.File.Delete(existPath);
                            }
                        }
                    }
                }

                if (existEmployer.EmployerImages.FirstOrDefault(x => x.IsPoster) != null)
                {
                    existEmployer.EmployerImages.FirstOrDefault(x => x.IsPoster).Image = fileName;
                }
                else
                {
                    EmployerImage employerImage = new EmployerImage()
                    {
                        EmployerId = existEmployer.Id,
                        IsPoster = true,
                        Image = fileName,
                    };
                    _context.EmployerImages.Add(employerImage);
                    employerEditDto.PosterImage = fileName;
                }
            }
            if (employerEditDto.PosterImage == null)
            {
                //candidateEditDto.Image = "";
                if (existEmployer.EmployerImages.Any(x => x.IsPoster))
                {
                    string rootPath = _env.WebRootPath;
                    var fileName = existEmployer.EmployerImages.FirstOrDefault(x => x.IsPoster).Image; ;
                    var path = Path.Combine(rootPath, "images/employerImage", fileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);

                    }
                    _context.EmployerImages.Remove(_context.EmployerImages.FirstOrDefault(x => x.EmployerId == existEmployer.Id && x.IsPoster));

                }

            }
            if (employerEditDto.Images != null)
            {
                foreach (var item in employerEditDto.Images)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("Images", "Mime type yanlisdir!");
                        return View(employerEditDto);
                    }

                    if (item.Length > (1024 * 1024) * 5)
                    {
                        ModelState.AddModelError("Images", "Faly olcusu 5MB-dan cox ola bilmez!");
                        return View(employerEditDto);
                    }

                    string rootPath = _env.WebRootPath;
                    var fileName = Guid.NewGuid().ToString() + item.FileName;
                    var path = Path.Combine(rootPath, "images/employerImage", fileName);

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    EmployerImage employerImage = new EmployerImage
                    {
                        Image = fileName,
                        IsPoster = false,
                        EmployerId = existEmployer.Id
                    };
                    _context.EmployerImages.Add(employerImage);
                }
            }
            if (existEmployer.EmployerImages != null)
            {
                foreach (var item in existEmployer.EmployerImages)
                {
                    if (employerEditDto.ImagesId != null)
                    {
                        if (!employerEditDto.ImagesId.Contains(item.Id) && item.Id != 0)
                        {
                            if (item.IsPoster == false)
                            {
                                string rootPath = _env.WebRootPath;
                                var fileName = item.Image;
                                var path = Path.Combine(rootPath, "images/employerImage", fileName);
                                if (System.IO.File.Exists(path))
                                {
                                    System.IO.File.Delete(path);
                                }
                                _context.EmployerImages.Remove(item);
                            }
                        }
     
                    }
                    else
                    {
                        if (employerEditDto.Images == null)
                        {
                            if (item.IsPoster == false)
                            {
                                string rootPath = _env.WebRootPath;
                                var fileName = item.Image;
                                var path = Path.Combine(rootPath, "images/employerImage", fileName);
                                if (System.IO.File.Exists(path))
                                {
                                    System.IO.File.Delete(path);
                                }
                                _context.EmployerImages.Remove(item);
                            }
                        }
        
                    }
                }
            }
            existEmployer.Name = employerEditDto.Name;
            existEmployer.FoundedDate = employerEditDto.FoundedDate;
            existEmployer.IsFeatured = false;
            existEmployer.CreatedAt = DateTime.UtcNow.AddHours(4);
            existEmployer.PhoneNumber = employerEditDto.PhoneNumber;
            existEmployer.Email = employerEditDto.Email;
            existEmployer.FacebookUrl = employerEditDto.FacebookUrl;
            existEmployer.InstagramUrl = employerEditDto.InstagramUrl;
            existEmployer.LinkedinUrl = employerEditDto.LinkedinUrl;
            existEmployer.TwitterUrl = employerEditDto.TwitterUrl;
            existEmployer.CompanyContent = employerEditDto.CompanyContent;
            existEmployer.Website = employerEditDto.Website;
            existEmployer.CityId = employerEditDto.CityId;
            existEmployer.CategoryId = employerEditDto.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult GetJobs(int id,int page=1)
        {
            ViewBag.TotalPageCount = Math.Ceiling(_context.Jobs.Where(x => x.EmployerId == id).Count() / 10m);
            ViewBag.SelectedPage = page;
            Employer employer = _context.Employers.FirstOrDefault(x => x.Id == id);
            if (employer == null) return RedirectToAction("index");
            List<Job> jobs = _context.Jobs.Include(x=>x.JobImages).Include(x=>x.JobCategory).Include(x=>x.Employer).ThenInclude(x=>x.Category).Include(x=>x.City).Where(x => x.EmployerId == id).Skip((page-1)*10).Take(10).ToList();
            if (jobs == null) return RedirectToAction("index");
            return View(jobs);
        }
        public IActionResult GetFollowers(int id,int page=1)
        {
            ViewBag.TotalPageCount = Math.Ceiling(_context.Followers.Where(x => x.EmployerId == id).Count() / 5m);
            ViewBag.SelectedPage = page;
            Employer employer = _context.Employers.FirstOrDefault(x => x.Id == id);
            if (employer == null) return RedirectToAction("index");
            List<Follower> followers = _context.Followers.Include(x => x.Candidate).ThenInclude(x=>x.CandidateImages).Include(x => x.Employer).Where(x => x.EmployerId==id).Skip((page-1)*5).Take(5).ToList();
            if (followers==null)
            {
                return RedirectToAction("index");
            }
            return View(followers);
        }
        public IActionResult SubmitJob(int newId)
        {
            ViewBag.Categories = _context.JobCategories.ToList();
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Languages = _context.Languages.ToList();
            Employer employer = _context.Employers.FirstOrDefault(x => x.Id == newId);
            if (employer == null) return RedirectToAction("index");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitJob(int newId,Job createJob)
        {
            ViewBag.Categories = _context.JobCategories.ToList();
            ViewBag.Cities = _context.Cities.ToList();
            ViewBag.Languages = _context.Languages.ToList();
            Employer employer = _context.Employers.FirstOrDefault(x => x.Id == newId);
            if (employer == null) return RedirectToAction("index");
            if (!ModelState.IsValid)
            {
                if (createJob.CityId == 0)
                {
                    ModelState.AddModelError("CityId", "Seher secilmelidir");
                }
                if (createJob.JobCategoryId == 0)
                {
                    ModelState.AddModelError("JobCategoryId", "Kateqoriya secilmelidir");

                }
                if (createJob.RequiredLanguageIds == null)
                {
                    ModelState.AddModelError("RequiredLanguageIds", "Language secilmelidir");
                }
                return View();
            }
            if (createJob.CityId == 0)
            {
                ModelState.AddModelError("CityId", "Seher secilmelidir");
                return View();
            }
            if (createJob.JobCategoryId == 0)
            {
                ModelState.AddModelError("JobCategoryId", "Kateqoriya secilmelidir");

                return View();
            }
            if (createJob.RequiredLanguageIds.Count() == 0)
            {
                ModelState.AddModelError("RequiredLanguageIds", "Language secilmelidir");
                return View();
            }
            createJob.EmployerId = newId;
            _context.Jobs.Add(createJob);
            _context.SaveChanges();
            if (createJob.File != null)
            {
                if (createJob.File.ContentType != "image/png" && createJob.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (createJob.File.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("File", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + createJob.File.FileName;
                var path = Path.Combine(rootPath, "images/jobImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    createJob.File.CopyTo(stream);
                }
                JobImage jobImage = new JobImage
                {
                    Image = fileName,
                    IsPoster = true,
                    JobId = createJob.Id,
                };
                _context.JobImages.Add(jobImage);
            }
            if (createJob.Images != null)
            {
                foreach (var item in createJob.Images)
                {
                    if (item.ContentType != "image/png" && item.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("File", "Jpeg ve ya png formatinda file daxil edilmelidir");
                        return View();
                    }
                    if (item.Length > (1024 * 1024) * 5)
                    {
                        ModelState.AddModelError("File", "File olcusu 5mb-dan cox olmaz!");
                        return View();
                    }
                    string rootPath = _env.WebRootPath;
                    var fileName = Guid.NewGuid().ToString() + item.FileName;
                    var path = Path.Combine(rootPath, "images/jobImage", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    JobImage jobImage = new JobImage
                    {
                        Image=fileName,
                        IsPoster=false,
                        JobId=createJob.Id,

                    };
                    _context.JobImages.Add(jobImage);
                }
            }
            if (createJob.RequiredLanguageIds != null)
            {
                foreach (var item in createJob.RequiredLanguageIds)
                {
                    if (_context.Languages.FirstOrDefault(x => x.Id == item) != null)
                    {
                        JobRequiredLanguage jobRequiredLanguage = new JobRequiredLanguage
                        {
                            Language = _context.Languages.FirstOrDefault(x => x.Id == item).Name,
                            JobId=createJob.Id
                        };
                        _context.JobRequiredLanguages.Add(jobRequiredLanguage);
                    }
                }
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult EditJob(int jobId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditJob(int jobId,Job editJob)
        {
            return View();
        }
    }
}
