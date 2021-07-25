using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.ViewModels
{
    public class CandidateAndEmployerLoginModel
    {
        [StringLength(maximumLength: 30)]
        public string UserName { get; set; }
        [StringLength(maximumLength: 50), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
