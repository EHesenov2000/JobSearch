using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class CandidateCV
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        [Required]
        public string CVName { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
