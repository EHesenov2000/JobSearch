using JobSearchFullWebSite.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class Apply
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        [StringLength(maximumLength: 20)]
        [Required]
        public string ContactPhone { get; set; }
        //[StringLength(maximumLength: 100)]
        //public string UserName { get; set; }
        [StringLength(maximumLength: 100)]
        public string FullName { get; set; }
        public DateTime RequestDate { get; set; }
        public ApplyStatus ApplyStatus { get; set; }
    }   
}
