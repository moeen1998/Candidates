using Candidates.Core.DTOs;
using Candidates.Core.Models;

namespace Candidates.Core.Interfaces.Services
{
    public interface ICandidateService
    {
        Task<ResponseDTO> Handle(CandidateDTO candidateDTO);
        Task<ResponseDTO> UpdateCandidate(Candidate candidate, CandidateDTO candidateDTO);
        Task<ResponseDTO> AddCandidate(CandidateDTO candidateDTO);
    }
}
