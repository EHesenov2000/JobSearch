using JobSearchFullWebSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.ViewModels
{
    public class CandidateEditModel
    {

        [StringLength(maximumLength: 30)]
        public string UserName { get; set; }

        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmedPassword { get; set; }
        [NotMapped]
        [StringLength(maximumLength: 50)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        public AppUser AppUser { get; set; }
    }
}
