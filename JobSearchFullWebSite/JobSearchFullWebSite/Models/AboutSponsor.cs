using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class AboutSponsor
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        [Required(ErrorMessage ="Sekil daxil edilmelidir")]
        public string SponsorImage { get; set; }
        [NotMapped]
        public IFormFile AboutSponsorImage { get; set; }
    }
}
