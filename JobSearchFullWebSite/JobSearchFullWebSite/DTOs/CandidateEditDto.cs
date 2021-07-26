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
        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum uzunluq 50-dir")]
        [Required]
        public string FullName { get; set; } //
        [Required]
        public int WaitingSalary { get; set; }//
        public JobSalaryForTime SalaryForTime { get; set; }//
        public DateTime BirthdayDate { get; set; }//
        [StringLength(maximumLength: 1000, ErrorMessage = "Maksimum uzunluq 1000-dur")]
        public string AboutCandidateTextEditor { get; set; }//
        public RequiredExperience Experience { get; set; }//
        public Gender Gender { get; set; }//
        public int Age { get; set; }//
        public Qualification Qualification { get; set; }//
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dur")]
        public string Email { get; set; }//
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dur")]
        public string PhoneNumber { get; set; }//
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string FacebookUrl { get; set; }//
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string TwitterUrl { get; set; }//
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string LinkedinUrl { get; set; }//
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string InstagramUrl { get; set; }//
        [NotMapped]
        public IFormFile Image { get; set; }//
        [NotMapped]
        public int? ImageId { get; set; }//

        public int CityId { get; set; }//
        public City City { get; set; }//
        public int PositionId { get; set; }//
        public Position Position { get; set; }//
        [NotMapped]
        public List<int> KnowingLanguageIds { get; set; }
        public List<CandidateKnowingLanguage> KnowingLanguages { get; set; }//
    }
}
