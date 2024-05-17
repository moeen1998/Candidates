using AutoMapper;
using Azure;
using Candidates.Core.DTOs;
using Candidates.Core.Enums;
using Candidates.Core.Interfaces;
using Candidates.Core.Interfaces.Services;
using Candidates.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Candidates.EF.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CandidateService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> Handle(CandidateDTO candidateDTO)
        {
            ResponseDTO result;

            Candidate candidate = await _unitOfWork.Repository<Candidate>().FindAsync(c => c.Email == candidateDTO.Email);

            if (candidate is null)
            {
                result = await AddCandidate(candidateDTO);
            }
            else
            {
                result = await UpdateCandidate(candidate, candidateDTO);
            }

            return result;
        }

        public async Task<ResponseDTO> AddCandidate(CandidateDTO candidateDTO)
        {
            Candidate candidate = _mapper.Map<Candidate>(candidateDTO);

            await _unitOfWork.Repository<Candidate>().Add(candidate);
            await _unitOfWork.SaveChangesAsync();

            return new ResponseDTO(ResponseStatusCode.Created, true, candidate, "Created");
        }

        public async Task<ResponseDTO> UpdateCandidate(Candidate candidate, CandidateDTO candidateDTO)
        {
            _mapper.Map(candidateDTO, candidate);

            _unitOfWork.Repository<Candidate>().Update(candidate);
            await _unitOfWork.SaveChangesAsync();

            return new ResponseDTO(ResponseStatusCode.Ok, true, candidate, "Ok");
        }
    }
}
