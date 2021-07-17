using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class JobComment
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
    }
}
