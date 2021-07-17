using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class City
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dur")]
        [Required(ErrorMessage = "Kateqoriya adı daxil etməlisiz")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Image daxil etməlisiz")]
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "Kordinat daxil etməlisiz")]
        [StringLength(maximumLength: 20)]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Kordinat daxil etməlisiz")]
        [StringLength(maximumLength: 20)]
        public string Longitude { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Employer> Employers { get; set; }

    }
}
