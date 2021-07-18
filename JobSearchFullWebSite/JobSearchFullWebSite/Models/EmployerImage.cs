using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class EmployerImage
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        [Required]
        public string Image { get; set; }
        public bool IsPoster { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
