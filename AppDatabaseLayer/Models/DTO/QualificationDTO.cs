using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseLayer.Models.DTO
{
    public class QualificationDTO
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public Nullable<int> CandidateID { get; set; }

    }
}
