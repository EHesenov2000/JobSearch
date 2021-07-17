using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class Subscribe
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 30,ErrorMessage = "Maximum 30 simvol daxil edə bilərsiz!")]
        [Required]
        [EmailAddress(ErrorMessage = "Email address daxil edin!")]
        public string Email { get; set; }
    }
}
