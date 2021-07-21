using JobSearchFullWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.ViewModels
{
    public class EmployerIndexViewModel
    {
        public List<Employer> Employers { get; set; }
        public List<City> Cities { get; set; }
        public List<Category> Categories { get; set; }
        public Employer Employer { get; set; }
    }
}
