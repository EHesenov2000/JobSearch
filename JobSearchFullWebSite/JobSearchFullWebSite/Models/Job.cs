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
    public class Job
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        [NotMapped]
        public List<IFormFile> Images { get; set; }
        [NotMapped]
        public List<int?> ImagesId { get; set; }
        public int CityId { get; set; }
        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }

        [StringLength(maximumLength: 80, ErrorMessage = "Maksimum uzunluq 80-dir")]
        [Required(ErrorMessage = "İş adı daxil etməlisiz")]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public int OfferedMaxSalary { get; set; }
        public int OfferedMinSalary { get; set; }
        [Required(ErrorMessage = "Maaş üçün vaxt aralığı seçməlisiz.")]
        public JobSalaryForTime OfferedSalaryForTime { get; set; }
        [Required(ErrorMessage = "İş növü seçməlisiz")]
        public JobType JobType { get; set; }
        [Required(ErrorMessage = "Təcili vakansiya olub olmamasını seçməlisiz")]
        public bool IsUrgent { get; set; }
        [Required(ErrorMessage = "İşin öndə olub olmamasını seçməlisiz")]
        public bool IsFeatured { get; set; }
        [Required(ErrorMessage = "Vakansiyanın bitmə tarixini qeyd etməlisiz")]
        public DateTime ExpirationDate { get; set; }
        [Required(ErrorMessage = "Tələb edilən gender seçməlisiz")]
        public Gender RequiredGender { get; set; }
        [Required(ErrorMessage = "Tələb edilən qualification seçməlisiz")]
        public Qualification RequiredQualificationr { get; set; }
        [Required(ErrorMessage = "Tələb edilən təcrübə aralığı seçməlisiz")]
        public RequiredExperience RequiredExperience { get; set; }
        [Required(ErrorMessage = "İşçi səviyyəsi seçməlisiz")]
        public CareerLevel CareerLevel { get; set; }
        [Required(ErrorMessage = "İş haqqında məlumat daxil etməlisiz")]
        [StringLength(maximumLength: 2000, ErrorMessage = "Maksimum uzunluq 80-dir")]
        public string JobContentTextEditor { get; set; }
        public List<JobImage> JobImages { get; set; }
        public City City { get; set; }
        public int? EmployerId { get; set; }
        public Employer Employer { get; set; }
        public List<JobContact> Contacts { get; set; }
        [NotMapped]
        public List<int?> RequiredLanguageIds { get; set; }
        public List<JobRequiredLanguage> RequiredLanguages { get; set; }
        public List<JobComment> JobComments { get; set; }
        public List<Apply> Applies { get; set; }
        public List<ShortList> ShortLists { get; set; }

    }
}
