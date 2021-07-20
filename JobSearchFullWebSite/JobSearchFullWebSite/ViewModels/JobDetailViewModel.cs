using JobSearchFullWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.ViewModels
{
    public class JobDetailViewModel
    {
        public Job Job { get; set; }
        public EmployerImage EmployerImage { get; set; }
        public List<Job> RelatedJobs { get; set; }
        public JobContact JobContact { get; set; }
    }
}
