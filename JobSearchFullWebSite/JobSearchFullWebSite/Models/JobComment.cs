using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class JobComment
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
