using JobSearchFullWebSite.Enums;
using JobSearchFullWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.ViewModels
{
    public class JobIndexViewModel
    {
        public List<Job> Jobs { get; set; }
        public List<City> Cities { get; set; }
        public List<JobCategory> JobCategories { get; set; }
        public Job Job { get; set; }
        public JobType JobType { get; set; }
        public RequiredExperience Experience { get; set; }
        public CareerLevel CareerLevel { get; set; }
        public Qualification Qualification { get; set; }

    }
}
