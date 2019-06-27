using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDatabaseLayer.CRUD;
using AppDatabaseLayer.Models;
using AppDatabaseLayer.Models.DTO;

namespace AppDatabaseLayer
{
    public class CandidateService : ICandidateService
    {
        private CandidateRepository _candidateRepository;

        public CandidateService(CandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public List<CandidateDTO> GetCandidates(CandidateSearchParams searchParams)
        {
            using (var context = new CandidateDbContext())
            {
                var candidateDtos = _candidateRepository.GetCandidates(context, searchParams);
                return candidateDtos;
            }
        
        }

        public bool SaveCandidate( Candidate candidate)
        {
            using (var context = new CandidateDbContext())
            {
                var success = false;
                if (candidate != null && !string.IsNullOrEmpty(candidate.FirstName) && !string.IsNullOrEmpty(candidate.LastName) 
                    && !string.IsNullOrEmpty(candidate.Email) && !string.IsNullOrEmpty(candidate.PhoneNumber) && !string.IsNullOrEmpty(candidate.ZipCode))
                {
                    success = _candidateRepository.SaveCandidates(context, candidate);

                }

                return success;
            }
        }

        public bool SaveQualification(Qualification qualification)
        {
            using (var context = new CandidateDbContext())
            {
                var success = false;
                if (qualification != null && qualification.CandidateID != 0 && qualification.DateStarted != null
                   && qualification.DateCompleted != null && !string.IsNullOrEmpty(qualification.Name) && !string.IsNullOrEmpty(qualification.Type))
                {
                    success = _candidateRepository.SaveQualification(context, qualification);
                }
                return success;
            }
        }

            
    }
}
