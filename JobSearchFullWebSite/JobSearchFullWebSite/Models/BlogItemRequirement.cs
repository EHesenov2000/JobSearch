using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class BlogItemRequirement
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:200,ErrorMessage ="Maksimum uzunluq 200-dur")]
        public string Requirement { get; set; }
        public int BlogItemId { get; set; }
        public BlogItem BlogItem { get; set; }
    }
}
