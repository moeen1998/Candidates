using Candidates.Core.DTOs;
using Candidates.Core.Enums;
using Candidates.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Candidates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService CandidateService)
        {
            _candidateService = CandidateService;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ResponseDTO>> Add(CandidateDTO candidateDTO)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest(new ResponseDTO(ResponseStatusCode.InValidModel, false, ModelState)); 
                }

                return Ok(await _candidateService.Handle(candidateDTO));
            }

            catch (Exception ex)
            {
                return Ok(new ResponseDTO(ResponseStatusCode.ServerError, false, ex.Message));
            }
        }
    }
}
