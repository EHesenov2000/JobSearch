using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Services
{
    public class LayoutViewModelService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public LayoutViewModelService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }
        public List<City> GetCities()
        {
            return _context.Cities.ToList();
        }
        public List<JobCategory> GetTopFiveCategories()
        {
            int skipValue=_context.JobCategories.Count() - 5;
            return _context.JobCategories.Include(x=>x.Jobs).OrderBy(x=>x.Jobs.Count).Skip(skipValue).Take(5).ToList();
        }
        public Candidate GetLoginnedCandidate(string name)
        {
            AppUser user = _context.Users.FirstOrDefault(x => x.UserName == name);
            Candidate candidate = _context.Candidates.Include(x=>x.AppUser).FirstOrDefault(x => x.AppUserId == user.Id);
            return candidate;
        }
        public Employer GetLoginnedEmployer(string name)
        {
            AppUser user = _context.Users.FirstOrDefault(x => x.UserName == name);
            Employer employer = _context.Employers.Include(x => x.AppUser).FirstOrDefault(x => x.AppUserId == user.Id);
            return employer;
        }
    }
}
