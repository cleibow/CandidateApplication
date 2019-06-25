using AppDatabaseLayer.Models;
using AppDatabaseLayer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseLayer
{
    public class CandidateMapper
    {
        public List<Candidate> ConvertCandidateDtoToDbModel(List<CandidateDTO> candidateDtos)
        {
  

            var candidates = (from candidate in candidateDtos
                                 select new Candidate()
                                 {
                                     FirstName = candidate.FirstName,
                                     LastName = candidate.LastName,
                                     Email = candidate.Email,
                                     ZipCode = candidate.ZipCode,
                                     ID = candidate.ID,
                                     PhoneNumber = candidate.PhoneNumber,
                                     Qualifications = (from qualification in candidate.Qualifications
                                                       select new Qualification()
                                                       {
                                                           DateStarted = qualification.DateStarted,
                                                           DateCompleted = qualification.DateCompleted,
                                                           Name = qualification.Name,
                                                           ID = qualification.ID,
                                                           Type = qualification.Type,
                                                           CandidateID = candidate.ID
                                                       }).ToList()

                                 }).ToList();
            return candidates;
        }

    }
}
