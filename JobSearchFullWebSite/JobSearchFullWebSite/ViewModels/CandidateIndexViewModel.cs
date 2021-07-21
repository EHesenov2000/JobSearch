using JobSearchFullWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.ViewModels
{
    public class CandidateIndexViewModel
    {
        public List<Candidate> Candidates { get; set; }
        public List<City> Cities { get; set; }
        public List<Position> Positions { get; set; }
        public Candidate Candidate { get; set; }
    }
}
