using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseLayer.Models
{
    public class CandidateSearchParams
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; } 
        public QualificationSearchParams QualificationSearchParams {get;set;}

    }
    public class QualificationSearchParams
    {
        public DateTime? Date { get; set; }
        public bool? IsWorkExperience { get; set; }
        public bool? IsProfessionalCertification { get; set; }
        public bool? IsCollegeDegree { get; set; }
        public List<string> CertificationNames { get; set; }
    }

    
}
