using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using CrowdFoundAppTeam3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFoundAppTeam3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundingPackageController : ControllerBase
    {
        private readonly IFundingPackage _service;

        public FundingPackageController(IFundingPackage service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<FundingPackageDto>> CreateFundingPackage(FundingPackageDto fundingPackageDto, int ProjectId)
        {
            FundingPackageDto? result = await _service.CreateFundingPackageAsync(fundingPackageDto, ProjectId);
            if (result == null) return NotFound("The specified Project Id is invalid or the Project has been removed. Could not create the funding package.");
            return Ok(result);
        }

    }
}
