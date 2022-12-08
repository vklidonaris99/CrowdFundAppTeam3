using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using CrowdFoundAppTeam3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFoundAppTeam3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackerController : ControllerBase
    {
        private readonly IBacker _service;

        public BackerController(IBacker service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BackerDto>>> Get()
        {
            List<BackerDto> dto = await _service.GetAllBackerAsync();
            if (dto is null)
                return NotFound("The Backer id is invalid or has been removed ");
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<BackerDtoFlat>> Post(BackerDtoFlat dto)
        {
            BackerDtoFlat? result = await _service.CreateBackerAsync(dto);
            if (result == null)
                return NotFound("Could not create Backer.");
            return Ok(result);
        }
    }
}

