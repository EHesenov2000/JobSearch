using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using JobSearchFullWebSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Controllers
{
    public class JobController : Controller
    {
        private readonly AppDbContext _context;
        public JobController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search, Job job,string[] types,string[] experiences,string[] careerLevels,string[] qualifications, int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Jobs.ToList().Count() / 9m);
            JobIndexViewModel jobVM = new JobIndexViewModel
            {
                Jobs = _context.Jobs.Include(x => x.JobImages).Include(x => x.JobCategory).Include(X => X.City).ToList(),
                Cities = _context.Cities.ToList(),
                JobCategories = _context.JobCategories.ToList(),

            };
            if (search != null)
            {
                jobVM.Jobs = jobVM.Jobs.Where(x => x.Name.ToUpper().Contains(search.ToUpper().Trim())).ToList();
            }

            if (job.City != null)
            {
                if (job.City.Id != 0)
                {
                    City city = _context.Cities.FirstOrDefault(x => x.Id == job.City.Id);
                    jobVM.Jobs = jobVM.Jobs.Where(x => x.City.CityName == city.CityName).ToList();
                }
            }
            if (job.JobCategory != null)
            {
                if (job.JobCategory.Id != 0)
                {
                    JobCategory jobCategory = _context.JobCategories.FirstOrDefault(x => x.Id == job.JobCategory.Id);
                    jobVM.Jobs = jobVM.Jobs.Where(x => x.JobCategory.Name == jobCategory.Name).ToList();
                }
            }

            List<Job> sendJobs = new List<Job>();
            if (types != null)
            {
                foreach (var item in types)
                {
                    if (item == Enums.JobType.Freelance.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.JobType == Enums.JobType.Freelance).ToList());
                    }
                    else if (item == Enums.JobType.FullTime.ToString())
                    {
                        sendJobs.AddRange( jobVM.Jobs.Where(x => x.JobType == Enums.JobType.FullTime).ToList());
                    }
                    else if (item == Enums.JobType.PartTime.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.JobType == Enums.JobType.PartTime).ToList());
                    }
                    else if (item == Enums.JobType.Internship.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.JobType == Enums.JobType.Internship).ToList());
                    }
                    else if (item == Enums.JobType.Temporary.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.JobType == Enums.JobType.Temporary).ToList());
                    }
                }
            }
            if (experiences != null)
            {
                foreach (var item in experiences)
                {
                    if (item == Enums.RequiredExperience.Fresh.ToString())
                    {
                        sendJobs.AddRange( jobVM.Jobs.Where(x => x.RequiredExperience == Enums.RequiredExperience.Fresh).ToList());
                    }
                    else if (item == Enums.RequiredExperience.Year_1.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.RequiredExperience == Enums.RequiredExperience.Year_1).ToList());
                    }
                    else if (item == Enums.RequiredExperience.Year_2.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.RequiredExperience == Enums.RequiredExperience.Year_2).ToList());
                    }
                    else if (item == Enums.RequiredExperience.Year_3.ToString())
                    {
                        sendJobs.AddRange( jobVM.Jobs.Where(x => x.RequiredExperience == Enums.RequiredExperience.Year_3).ToList());
                    }
                    else if (item == Enums.RequiredExperience.Year_4.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.RequiredExperience == Enums.RequiredExperience.Year_4).ToList());
                    }
                    else if (item == Enums.RequiredExperience.More.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.RequiredExperience == Enums.RequiredExperience.More).ToList());
                    }
                }
            }
            if (careerLevels != null)
            {
                foreach (var item in careerLevels)
                {
                    if (item == Enums.CareerLevel.Manager.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.CareerLevel == Enums.CareerLevel.Manager).ToList());
                    }
                    else if (item == Enums.CareerLevel.Officer.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.CareerLevel == Enums.CareerLevel.Officer).ToList());
                    }
                    else if (item == Enums.CareerLevel.Student.ToString())
                    {
                        sendJobs.AddRange( jobVM.Jobs.Where(x => x.CareerLevel == Enums.CareerLevel.Student).ToList());
                    }
                    else if (item == Enums.CareerLevel.Executive.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.CareerLevel == Enums.CareerLevel.Executive).ToList());
                    }
                    else if (item == Enums.CareerLevel.Others.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.CareerLevel == Enums.CareerLevel.Others).ToList());
                    }
                }
            }
            if (qualifications != null)
            {
                foreach (var item in qualifications)
                {
                    if (item == Enums.Qualification.Certificate.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.RequiredQualificationr == Enums.Qualification.Certificate).ToList());
                    }
                    else if (item == Enums.Qualification.Associate.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.RequiredQualificationr == Enums.Qualification.Associate).ToList());
                    }
                    else if (item == Enums.Qualification.Bachelor_Degree.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.RequiredQualificationr == Enums.Qualification.Bachelor_Degree).ToList());
                    }
                    else if (item == Enums.Qualification.Master_Degree.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.RequiredQualificationr == Enums.Qualification.Master_Degree).ToList());
                    }
                    else if (item == Enums.Qualification.Doctorate_Degree.ToString())
                    {
                        sendJobs.AddRange(jobVM.Jobs.Where(x => x.RequiredQualificationr == Enums.Qualification.Doctorate_Degree).ToList());
                    }
                }
            }
            if (sendJobs.Count()!=0)
            {
                jobVM.Jobs = sendJobs;
                
            }
            jobVM.Jobs = jobVM.Jobs.Distinct().ToList();
            jobVM.Jobs = jobVM.Jobs.Skip((page - 1) * 9).Take(9).ToList();
            return View(jobVM);
        }
        public IActionResult Detail(int id)
        {
            if (!_context.Jobs.Any(x => x.Id == id))
            {
                return RedirectToAction("index", "home");
            }

            Job existjob = _context.Jobs.Include(x=>x.Employer).FirstOrDefault(x => x.Id == id);
            JobDetailViewModel JobVM = new JobDetailViewModel
            {
                Job = _context.Jobs.Include(x => x.JobCategory).Include(x => x.JobImages).Include(x=>x.JobComments).ThenInclude(x=>x.AppUser).ThenInclude(x=>x.Candidate).Include(x => x.City).Include(x => x.Employer).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == id),
                EmployerImage = _context.EmployerImages.FirstOrDefault(x => x.IsPoster),
                RelatedJobs = _context.Jobs.Include(x=>x.JobImages).Include(x => x.JobCategory).Include(x => x.City).Where(x => x.Employer.Name == existjob.Employer.Name).ToList(),
                AppUser= _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name),
            };

            return View(JobVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetContact(JobContact jobContact,int id)
        {
            jobContact.JobId = id;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Sehv askarlandi");
                return RedirectToAction("detail","job",id);
            }
            _context.JobContacts.Add(jobContact);
            _context.SaveChanges();
            return RedirectToAction("index","job");
        }

        public IActionResult AddJobToShortlist(int jobId,int candidateId)
        {
            Candidate candidate = _context.Candidates.FirstOrDefault(x => x.Id == candidateId);
            Job job = _context.Jobs.FirstOrDefault(x => x.Id == jobId);
            if (job == null || candidate == null) return RedirectToAction("index");
            ShortList shortList = new ShortList
            {
                CandidateId = candidateId,
                JobId = jobId
            };
            _context.ShortLists.Add(shortList);
            _context.SaveChanges();
            return RedirectToAction();
        }
        public IActionResult RemoveJobFromShortlist(int id)
        {
            ShortList shortList = _context.ShortLists.FirstOrDefault(x => x.Id == id);
            if (shortList==null)
            {
                return RedirectToAction("index");
            }
            _context.ShortLists.Remove(shortList);
            _context.SaveChanges();
            return RedirectToAction();
        }
        //[Authorize(Roles = "Candidate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(JobComment coment)
        {
            if(coment.JobId==0 || coment.AppUserId==null ||coment.Comment==null || coment.Comment.Length>500) return RedirectToAction("index");
            Job job = _context.Jobs.Include(x => x.JobComments).FirstOrDefault(x => x.Id == coment.JobId);

            if (job == null) return RedirectToAction("index");

            var user = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            coment.AppUserId = user.Id;

            if (_context.JobComments.Any(x => x.JobId == coment.JobId && x.AppUserId == user.Id))
            {
                return RedirectToAction("index");
            }

            double commentCount = job.JobComments.Count() + 1;
            coment.CreatedAt = DateTime.UtcNow;
            _context.JobComments.Add(coment);

            _context.SaveChanges();

            return RedirectToAction("detail", new { id = coment.JobId });
        }
        //[Authorize(Roles = "Member")]
        public IActionResult LoadComment(int id, int page = 1)
        {
            List<JobComment> comments = _context.JobComments.Include(x => x.AppUser).Where(x => x.JobId == id).OrderByDescending(x => x.CreatedAt).Skip((page - 1) * 2).Take(2).ToList();

            return PartialView("_CourseComments", comments);
        }
    }
}
