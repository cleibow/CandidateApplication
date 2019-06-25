using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDatabaseLayer.Models;
using System.Data.Entity;
using AppDatabaseLayer.Models.DTO;

namespace AppDatabaseLayer.CRUD
{
    public class CandidateRepository : ICandidateRepository
    {

        public CandidateRepository()
        {
        }

        public List<CandidateDTO> GetCandidates(CandidateDbContext _context, CandidateSearchParams searchParams)
        {
            {
                if (searchParams != null && _context != null)
                {
                    var candidates = _context.Candidates;
                    var qualifications = _context.Qualifications;

                    var candidateDTOs = (from candidate in candidates
                                         select new CandidateDTO()
                                         {
                                             FirstName = candidate.FirstName,
                                             LastName = candidate.LastName,
                                             Email = candidate.Email,
                                             ZipCode = candidate.ZipCode,
                                             ID = candidate.ID,
                                             Qualifications = (from qualification in qualifications
                                                               where qualification.CandidateID == candidate.ID
                                                               select new QualificationDTO()
                                                               {
                                                                   DateStarted = qualification.DateStarted,
                                                                   DateCompleted = qualification.DateCompleted,
                                                                   Name = qualification.Name,
                                                                   ID = qualification.ID,
                                                                   Type = qualification.Type,
                                                                   CandidateID = candidate.ID
                                                               }).ToList()

                                         }).ToList();
                    var filteredCandidateDTOs = candidateDTOs.Where(c => (string.IsNullOrEmpty(searchParams.FirstName) || c.FirstName.ToLower() == searchParams.FirstName.ToLower())
                                                 && (string.IsNullOrEmpty(searchParams.LastName) || c.LastName.ToLower() == searchParams.LastName.ToLower())
                                                 && (string.IsNullOrEmpty(searchParams.Email) || c.Email.ToLower() == searchParams.Email.ToLower())
                                                 && (string.IsNullOrEmpty(searchParams.PhoneNumber) || c.PhoneNumber.ToLower() == searchParams.PhoneNumber.ToLower())
                                                 && (string.IsNullOrEmpty(searchParams.ZipCode) || c.ZipCode.ToLower() == searchParams.ZipCode.ToLower())
                                                        // if dont have qualification search params, dont care about candidate qualifications 
                                                        && (searchParams.QualificationSearchParams == null
                                                        // otherwise filter qualifications
                                                        || (c.Qualifications != null && c.Qualifications.Any(q => (searchParams.QualificationSearchParams.Date == null || ((q.DateStarted < searchParams.QualificationSearchParams.Date) && (q.DateCompleted > searchParams.QualificationSearchParams.Date))
                                                            && (searchParams.QualificationSearchParams.IsCollegeDegree == null || q.Type.ToLower() == "college degree")
                                                            && (searchParams.QualificationSearchParams.IsProfessionalCertification == null || q.Type.ToLower() == "professional certification")
                                                            && (searchParams.QualificationSearchParams.IsWorkExperience == null || q.Type.ToLower() == "work experience")
                                                            && (searchParams.QualificationSearchParams.CertificationNames != null && searchParams.QualificationSearchParams.CertificationNames.Contains(q.Name.ToLower()))
                                                            )))
                                                 )).ToList();


                    return filteredCandidateDTOs;

                }

                return new List<CandidateDTO>();
            }
        }

        public bool SaveCandidates(CandidateDbContext _context, List<Candidate> candidates)
        {
            
                try
                {
                    _context.Candidates.AddRange(candidates);
                    _context.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }

        }
    }
}
