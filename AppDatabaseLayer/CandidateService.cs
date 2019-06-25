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

        public bool SaveCandidates( List<Candidate> candidates)
        {
            using (var context = new CandidateDbContext())
            {
                var success = _candidateRepository.SaveCandidates(context, candidates);
                return success;
            }
        }
    }
}
