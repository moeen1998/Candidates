using AutoMapper;
using Candidates.Core.DTOs;
using Candidates.Core.Models;

namespace Candidates.Core.MappingProfiles;
public class CandidateProfile : Profile
{
    public CandidateProfile()
    {
        CreateMap<CandidateDTO, Candidate>().ReverseMap();
    }
}
