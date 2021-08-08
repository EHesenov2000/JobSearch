using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class BlogItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string Subject { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string FullImage { get; set; }
        [NotMapped]
        public IFormFile FullImageFile { get; set; }
        [Required]
        [StringLength(maximumLength: 1000, ErrorMessage = "Maksimum uzunluq 1000-dir")]
        public string DescriptionTextEditor { get; set; }
        [StringLength(maximumLength: 200, ErrorMessage = "Maksimum uzunluq 200-dur")]
        public string BackBlueTextHead { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum uzunluq 50-dir")]
        public string BackBlueTextFoot { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string ContainerImage { get; set; }
        [NotMapped]
        public IFormFile ContainerImageFile { get; set; }
        public List<BlogItemLearn> BlogItemLearns { get; set; }
        public List<BlogItemRequirement> BlogItemRequirements { get; set; }
    }
}
