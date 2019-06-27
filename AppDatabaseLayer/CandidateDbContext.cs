using AppDatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseLayer
{
    public class CandidateDbContext : DbContext, IDbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        public CandidateDbContext() : base("CandidateConnectionString")
        {
            Database.SetInitializer<CandidateDbContext>(new UniDBInitializer<CandidateDbContext>());

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        private class UniDBInitializer<T> : DropCreateDatabaseAlways<CandidateDbContext>
        {

            protected override void Seed(CandidateDbContext context)
            {

                var candidate1 = new Candidate()
                {
                    FirstName = "Cooper",
                    LastName = "Leibow",
                    Email = "leibowcooper@gmail.com",
                    ZipCode = "77007",
                    PhoneNumber = "2144040949",
                    Qualifications = new List<Qualification>()
                {
                    new Qualification()
                    {
                        Type = "Work Experience",
                        DateStarted =  new DateTime(2011, 1, 1),
                        DateCompleted = new DateTime(2012, 1, 1),
                        CandidateID = 1,
                        ID = 1
                    }
                }
                };


                context.Candidates.Add(candidate1);
                context.SaveChanges();
                base.Seed(context);
            }
        }


    }
}
