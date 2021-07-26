using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class Language
    {
        public int Id { get; set; }
        [StringLength(maximumLength:20,ErrorMessage ="Maksimum uzunluq 20-dir")]
        [Required]
        public string Name { get; set; }
    }
}
