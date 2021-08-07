using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.DTOs
{
    public class CandidateResumeEditDto
    {
        public int Id { get; set; }
        [NotMapped]
        public List<IFormFile> Images { get; set; }
        public List<int?> ImagesId { get; set; }

        [NotMapped]
        public IFormFile CandidateCV { get; set; }
        public List<int?> CandidateCVsId { get; set; }
        public List<int?> CandidateEducationItemsId { get; set; }
        public List<int?> CandidateWorkItemsId { get; set; }
        public List<int?> CandidateAwardItemsId { get; set; }
        public List<int?> CandidateSkillsId { get; set; }
        public List<CandidateSkill> CandidateSkills { get; set; }
        public List<CandidateImage> CandidateImages { get; set; }
        public List<CandidateCV> CandidateCVs { get; set; }
        public List<CandidateEducationItem> CandidateEducationItems { get; set; }
        public List<CandidateWorkItem> CandidateWorkItems { get; set; }
        public List<CandidateAwardItem> CandidateAwardItems { get; set; }
    }
}
