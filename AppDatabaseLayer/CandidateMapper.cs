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
        public Candidate ConvertCandidateDtoToDbModel(CandidateDTO candidateDto)
        {
  

    
            var candidate = new Candidate()
            {
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                Email = candidateDto.Email,
                ZipCode = candidateDto.ZipCode,
                ID = candidateDto.ID,
                PhoneNumber = candidateDto.PhoneNumber,
                Qualifications = (from qualification in candidateDto.Qualifications
                                  select new Qualification()
                                  {
                                      DateStarted = qualification.DateStarted,
                                      DateCompleted = qualification.DateCompleted,
                                      Name = qualification.Name,
                                      ID = qualification.ID,
                                      Type = qualification.Type,
                                      CandidateID = candidateDto.ID
                                  }).ToList()

            };
            return candidate;
        }

        public Qualification ConvertQualificationDtoToDbModel(QualificationDTO qualificationDto, int candidateId)
        {
            var qualification = new Qualification()
            {
                DateStarted = qualificationDto.DateStarted,
                DateCompleted = qualificationDto.DateCompleted,
                Name = qualificationDto.Name,
                ID = qualificationDto.ID,
                Type = qualificationDto.Type,
                CandidateID = candidateId
            };
            return qualification;
        }

    }
}
