using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class CandidateWorkItem
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum uzunluq 50-dir")]
        [Required]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum uzunluq 50-dir")]
        [Required]
        public string WorkPlace { get; set; }
        [StringLength(maximumLength: 200, ErrorMessage = "Maksimum uzunluq 200-dur")]
        [Required]
        public string Content { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
