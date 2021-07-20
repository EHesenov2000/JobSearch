using JobSearchFullWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.ViewModels
{
    public class BlogDetailViewModel
    {
        public BlogItem BlogItem { get; set; }
        public List<BlogItem> BlogItems { get; set; }
    }
}
