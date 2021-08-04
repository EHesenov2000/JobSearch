using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        [Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile TestimonialImage { get; set; }
        //[NotMapped]
        //public List<int?> TestimonialImageId { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum uzunluq 50-dir")]
        [Required]
        public string BlueText { get; set; }
        [StringLength(maximumLength: 200, ErrorMessage = "Maksimum uzunluq 200-dur")]
        [Required]
        public string Content { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum uzunluq 50-dir")]
        [Required]
        public string Name { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dur")]
        [Required]
        public string Position { get; set; }
    }
}
