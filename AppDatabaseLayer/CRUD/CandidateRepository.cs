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
                                             PhoneNumber = candidate.PhoneNumber,
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
                    var filteredCandidateDTOs = candidateDTOs.Where(c => (string.IsNullOrEmpty(searchParams.FirstName) || c.FirstName.ToLower().Contains(searchParams.FirstName.ToLower()))
                                                 && (string.IsNullOrEmpty(searchParams.LastName) || c.LastName.ToLower().Contains(searchParams.LastName.ToLower()))
                                                 && (string.IsNullOrEmpty(searchParams.Email) || c.Email.ToLower().Contains(searchParams.Email.ToLower()))
                                                 && (string.IsNullOrEmpty(searchParams.PhoneNumber) || c.PhoneNumber == searchParams.PhoneNumber)
                                                 && (string.IsNullOrEmpty(searchParams.ZipCode) || c.ZipCode == searchParams.ZipCode)
                                                        // if dont have qualification search params, dont care about candidate qualifications 
                                                        && (searchParams.QualificationSearchParams == null
                                                        // otherwise filter qualifications
                                                        || (c.Qualifications != null && c.Qualifications.Any(q => (searchParams.QualificationSearchParams.Date == null || (q.DateStarted < searchParams.QualificationSearchParams.Date) && (q.DateCompleted > searchParams.QualificationSearchParams.Date))
                                                            && (searchParams.QualificationSearchParams.Type == null || q.Type?.ToLower() == searchParams.QualificationSearchParams.Type?.ToLower())
                                                            // Was going to allow muliple names to be filtered in one query, but ran out of time to implement in UI 
                                                            && (searchParams.QualificationSearchParams.CertificationNames == null || searchParams.QualificationSearchParams?.CertificationNames?.Count() == 0 || (q.Name != null && q.Name.Contains(searchParams?.QualificationSearchParams?.CertificationNames[0])))
                                                            ))
                                                 )).ToList();


                    return filteredCandidateDTOs.Count > 0? filteredCandidateDTOs : new List<CandidateDTO>();

                }

                return new List<CandidateDTO>();
            }
        }

        public bool SaveCandidates(CandidateDbContext context, Candidate candidate)
        {

            try
            {
                context.Candidates.Add(candidate);
                context.SaveChanges();
                return true;
            }

            catch (Exception e)
            {
                return false;
            }

        }

        public bool SaveQualification(CandidateDbContext context, Qualification qualification)
        {
            try
            {
                context.Qualifications.Add(qualification);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
