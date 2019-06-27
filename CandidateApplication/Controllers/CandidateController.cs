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
using System.Web.Http.Cors;

namespace CandidateApplication.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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
            if (candidates != null)
            {
                return Ok(candidates);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/createCandidate")]
        public IHttpActionResult SaveCandidate(CandidateDTO candidateDto)
        {
            var candidate = _mapper.ConvertCandidateDtoToDbModel(candidateDto);
            var success = Task.Run(() => _canidateService.SaveCandidate(candidate)).Result;
            if (success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/createQualification/{id}")]
        public IHttpActionResult SaveQualification(QualificationDTO qualificationDTO, int id)
        {
            var qualification = _mapper.ConvertQualificationDtoToDbModel(qualificationDTO, id);
            var success = Task.Run(() => _canidateService.SaveQualification(qualification)).Result;
            if (success)
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}
