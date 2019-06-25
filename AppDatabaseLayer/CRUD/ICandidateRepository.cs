using AppDatabaseLayer.Models;
using AppDatabaseLayer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseLayer.CRUD
{
    public interface ICandidateRepository
    {
        List<CandidateDTO> GetCandidates(CandidateDbContext context, CandidateSearchParams candidateSearchParams);
        bool SaveCandidates(CandidateDbContext context, List<Candidate> candidateDTOs);

    }
}
