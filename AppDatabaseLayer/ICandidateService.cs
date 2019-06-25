using AppDatabaseLayer.Models;
using AppDatabaseLayer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseLayer
{
    public interface ICandidateService
    {
        List<CandidateDTO> GetCandidates(CandidateSearchParams searchParams);
        bool SaveCandidates(List<Candidate> candidates);
    }
}
