using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class Term
    {
        public int Id { get; set; }
        [StringLength(maximumLength:2500,ErrorMessage ="Maksimum uzunlud 2500-dur")]
        [Required]
        public string SiteTerm { get; set; }
    }
}
