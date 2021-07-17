using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class JobRequiredLanguage
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dur")]
        [Required]
        public string Language { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
