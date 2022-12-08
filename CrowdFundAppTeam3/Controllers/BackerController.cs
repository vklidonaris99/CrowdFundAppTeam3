using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFoundAppTeam3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackerController : ControllerBase
    {
        private readonly BackerService _service;

        public BackerController(BackerService service)
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
        public async Task<ActionResult<BackerDto>> Post(BackerDto dto)
        {
            BackerDto? result = await _service.CreateBackerAsync(dto);
            if (result == null)
                return NotFound("The specified Backer Id is invalid or the Backer has been removed. Could not create Backer.");
            return Ok(result);
        }
      
    }
}

