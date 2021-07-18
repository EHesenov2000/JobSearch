using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class JobImage
    { 
        public int Id { get;set; }
        [StringLength(maximumLength: 100,ErrorMessage ="Maksimum uzunluq 100-dur")]
        [Required]
        public string Image { get; set; }
        public bool IsPoster { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
