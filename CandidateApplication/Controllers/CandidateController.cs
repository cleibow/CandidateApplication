using AppDatabaseLayer;
using AppDatabaseLayer.CRUD;
using AppDatabaseLayer.Models;
using AppDatabaseLayer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CandidateApplication.Controllers
{
    public class CandidateController : ApiController
    {
        private readonly CandidateService _canidateService;
        private readonly CandidateMapper _mapper;

        public CandidateController(CandidateService candidateService, CandidateMapper mapper)
        {
            _canidateService = candidateService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/candidates")]
        public IHttpActionResult GetCandidates(CandidateSearchParams candidateSearchParams)
        {
            var candidates = Task.Run(() => _canidateService.GetCandidates(candidateSearchParams)).Result;
            if (candidates != null && candidates.Count > 0)
            {
                return Ok(candidates);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/createCandidates")]
        public IHttpActionResult SaveCandidates(List<CandidateDTO> candidateDtos)
        {
            var candidates = _mapper.ConvertCandidateDtoToDbModel(candidateDtos);
            var success = Task.Run(() => _canidateService.SaveCandidates(candidates)).Result;
            if (success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
