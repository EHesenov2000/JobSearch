using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class BlogItemLearn
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maksimum uzunluq 100-dur")]
        public string Learn { get; set; }
        public int BlogItemId { get; set; }
        public BlogItem BlogItem { get; set; }
    }
}
