using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class FAQ
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 500, ErrorMessage = "Maksimum uzunluq 500-dur")]
        public string Question { get; set; }
    }
}
