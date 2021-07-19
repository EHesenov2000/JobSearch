using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class JobCategory
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dur")]
        [Required(ErrorMessage = "Kateqoriya adı daxil etməlisiz")]
        public string Name { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
