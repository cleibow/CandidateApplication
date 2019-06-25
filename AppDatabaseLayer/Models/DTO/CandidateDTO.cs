using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseLayer.Models.DTO
{
    public class CandidateDTO
    {
        public CandidateDTO()
        {
            this.Qualifications = new List<QualificationDTO>();
        }

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }

        public List<QualificationDTO> Qualifications { get; set; }
    }
}
