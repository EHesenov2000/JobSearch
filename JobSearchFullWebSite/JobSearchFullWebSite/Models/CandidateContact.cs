using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class CandidateContact
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 80, ErrorMessage = "Maksimum uzunluq 80-dir")]
        [Required(ErrorMessage = "Mövzu daxil edilməlidir")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Email daxil edilməlidir")]
        [StringLength(maximumLength: 30, ErrorMessage = "Maksimum uzunluq 30-dir")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nömrə daxil edilməlidir")]
        [StringLength(maximumLength: 20, ErrorMessage = "Maksimum uzunluq 20-dir")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Mesaj daxil edilməlidir")]
        [StringLength(maximumLength: 500, ErrorMessage = "Maksimum uzunluq 500-dir")]
        public string Message { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
