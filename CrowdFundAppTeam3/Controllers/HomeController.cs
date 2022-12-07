using CrowdFoundAppTeam3.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFoundAppTeam3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProjectService _service;

        public HomeController(IProjectService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await _service.GetMostFundedProjectsAsync());
        }
    }
}
