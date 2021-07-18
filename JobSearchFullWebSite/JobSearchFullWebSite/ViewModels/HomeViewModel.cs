using JobSearchFullWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.ViewModels
{
    public class HomeViewModel
    {
        public List<HowWork> HowWorks { get; set; }
        public List<Job> Jobs { get; set; }
        public List<City> Cities { get; set; }
        public List<Candidate> Candidates { get; set; }
        public List<BlogItem> BlogItems { get; set; }
    }
}
