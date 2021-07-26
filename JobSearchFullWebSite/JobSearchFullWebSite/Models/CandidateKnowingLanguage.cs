using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Models
{
    public class CandidateKnowingLanguage
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public List<CandidateKnowingLanguage> KnowingLanguages { get; set; }
    }
}
