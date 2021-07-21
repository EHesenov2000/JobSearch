using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class Position
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100,ErrorMessage ="Maksimum uzunluq 100-dur")]
        [Required]
        public string PositionName { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}
