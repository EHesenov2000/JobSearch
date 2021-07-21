using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class SiteContact
    {
        public int Id { get; set; }
        [StringLength(maximumLength:60,ErrorMessage ="Maksimum uzunluq 60-dir")]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength:30,ErrorMessage ="Maksimum uzunluq 30-dur")]
        public string Email { get; set; }
        [StringLength(maximumLength:150,ErrorMessage ="Maksimum uzunluq 150-dir")]
        [Required]
        public string Subject { get; set; }
        [Required]
        [StringLength(maximumLength:500,ErrorMessage ="Maksimum uzunluq 500-dur")]
        public string Comment { get; set; }
    }
}
