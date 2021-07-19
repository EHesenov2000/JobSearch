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

    }
}
