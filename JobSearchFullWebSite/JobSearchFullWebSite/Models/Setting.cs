using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength:150)]
        public string HeaderLogo { get; set; }
        [StringLength(maximumLength: 150)]
        public string HeaderResponsiveLogo { get; set; }
        [Required]
        [NotMapped]
        public IFormFile HeaderResponsiveLogoFile { get; set; }
        [Required]
        [NotMapped]
        public IFormFile HeaderLogoFile { get; set; }
        [StringLength(maximumLength:150)]
        public string FooterLogo { get; set; }
        [Required]
        [NotMapped]
        public IFormFile FooterLogoFile { get; set; }
        [StringLength(maximumLength:20)]
        [Required]
        public string Phone { get; set; }
        [StringLength(maximumLength:150)]
        [Required]
        public string Location { get; set; }
        [StringLength(maximumLength:30)]
        [Required]
        public string Email { get; set; }
        [StringLength(maximumLength:150)]
        [Required]
        public string FacebookUrl { get; set; }
        [StringLength(maximumLength: 150)]
        [Required]
        public string TwitterUrl { get; set; }
        [StringLength(maximumLength: 150)]
        [Required]
        public string InstagramUrl { get; set; }
        [StringLength(maximumLength: 150)]
        [Required]
        public string LinkedinUrl { get; set; }
    }
}
