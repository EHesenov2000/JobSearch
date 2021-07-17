using JobSearchFullWebSite.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "Maksimum uzunluq 50-dir")]
        [Required]
        public string FullName { get; set; } 
        public bool IsFeatured { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        [Required]
        public string Position { get; set; }
        public int WaitingSalary { get; set; }
        public JobSalaryForTime SalaryForTime { get; set; }
        public DateTime BirthdayDate { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(maximumLength: 1000, ErrorMessage = "Maksimum uzunluq 1000-dur")]
        public string AboutCandidateTextEditor { get; set; }
        public RequiredExperience Experience { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public Qualification Qualification { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dur")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string FacebookUrl { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string TwitterUrl { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string LinkedinUrl { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string InstagramUrl { get; set; }
        [NotMapped]
        public List<IFormFile> Images { get; set; }
        [NotMapped]
        public List<int?> ImagesId { get; set; }

        [NotMapped]
        public List<IFormFile> CandidateCVS { get; set; }
        [NotMapped]
        public List<int?> CandidateCVsId { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<CandidateSkill> CandidateSkills { get; set; }
        public List<CandidateKnowingLanguage> KnowingLanguages { get; set; }
        public List<CandidateImage> CandidateImages { get; set; }
        public List<CandidateCV> CandidateCVs { get; set; }
        public List<CandidateContact> CandidateContacts { get; set; }
        public List<CandidateEducationItem> CandidateEducationItems { get; set; }
        public List<CandidateWorkItem> CandidateWorkItems { get; set; }
        public List<CandidateAwardItem> CandidateAwardItems { get; set; }


    }
}


