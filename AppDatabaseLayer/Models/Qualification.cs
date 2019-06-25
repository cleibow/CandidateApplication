using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseLayer.Models
{
    public partial class Qualification : IEntity
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "Date")]
        public Nullable<System.DateTime> DateStarted { get; set; }
        [Column(TypeName = "Date")]
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<int> CandidateID { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
