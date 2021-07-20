using JobSearchFullWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.ViewModels
{
    public class AboutViewModel
    {
        public List<HowWork> HowWorks { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<AboutSponsor> AboutSponsors { get; set; }
        public About About { get; set; }
    }
}
