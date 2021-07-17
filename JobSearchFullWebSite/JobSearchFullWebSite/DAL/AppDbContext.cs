﻿using JobSearchFullWebSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.DAL.AppDbContext
{
    public class AppDbContext:DbContext
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


    }
}