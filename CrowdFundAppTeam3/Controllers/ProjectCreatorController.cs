using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFoundAppTeam3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCreatorController : ControllerBase
    {
        private readonly IProjectCreator service;

        public ProjectCreatorController(IProjectCreator service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectCreatorDto>> PostProjectCreator(ProjectCreatorDto projectCreatorDto)
        {
            ProjectCreatorDto? result = await service.CreateProjectCreatorAsync(projectCreatorDto);
            if (result == null) 
                return NotFound("Could not create Project Creator.");
            //Check dublicate
            return Ok(result);
        }
    }
}

