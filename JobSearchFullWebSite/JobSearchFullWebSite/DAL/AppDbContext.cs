using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.DAL.AppDbContext
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<HowWork> HowWorks { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<JobImage> JobImages { get; set; }
        public DbSet<JobContact> JobContacts { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<EmployerContact> EmployerContacts { get; set; }
        public DbSet<EmployerImage> EmployerImages { get; set; }
        public DbSet<CandidateAwardItem> CandidateAwardItems { get; set; }
        public DbSet<CandidateEducationItem> CandidateEducationItems { get; set; }
        public DbSet<CandidateWorkItem> CandidateWorkItems { get; set; }
        public DbSet<CandidateKnowingLanguage> CandidateKnowingLanguages { get; set; }
        public DbSet<JobRequiredLanguage> JobRequiredLanguages { get; set; }
        //public DbSet<JobComment> JobComments { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }
        public DbSet<CandidateCV> CandidateCVs { get; set; }
        public DbSet<CandidateImage> CandidateImages { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateContact> CandidateContacts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutSponsor> AboutSponsors { get; set; }
        public DbSet<AboutImage> AboutImages { get; set; }
        public DbSet<BlogItem> BlogItems { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<BlogItemLearn> BlogItemLearns { get; set; }
        public DbSet<BlogItemRequirement> BlogItemRequirements { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SiteContact> SiteContacts { get; set; }
    }
}
