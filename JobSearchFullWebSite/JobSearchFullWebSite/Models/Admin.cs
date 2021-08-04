using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
