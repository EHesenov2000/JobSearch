using JobSearchFullWebSite.Enums;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.DTOs
{
    public class CandidateEditDto
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum uzunluq 50-dir")]
        [Required]
        public string FullName { get; set; } //
        [Required]
        public int? WaitingSalary { get; set; }//
        [Required]
        public JobSalaryForTime? SalaryForTime { get; set; }//
        [Required]
        public DateTime? BirthdayDate { get; set; }//
        [StringLength(maximumLength: 1000, ErrorMessage = "Maksimum uzunluq 1000-dur")]
        [Required]
        public string AboutCandidateTextEditor { get; set; }//
        [Required]
        public RequiredExperience? Experience { get; set; }//
        [Required]
        public Gender? Gender { get; set; }//
        [Required]
        public int? Age { get; set; }//
        [Required]
        public Qualification? Qualification { get; set; }//
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dur")]
        [Required]
        public string Email { get; set; }//
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dur")]
        [Required]
        public string PhoneNumber { get; set; }//
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string FacebookUrl { get; set; }//
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string TwitterUrl { get; set; }//
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string LinkedinUrl { get; set; }//
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string InstagramUrl { get; set; }//
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }//
        public int CityId { get; set; }//
        public City City { get; set; }//
        public int PositionId { get; set; }//
        public Position Position { get; set; }//
        [NotMapped]
        public List<int?> KnowingLanguageIds { get; set; }
        public List<CandidateKnowingLanguage> KnowingLanguages { get; set; }//
    }
}
