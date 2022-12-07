using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;

namespace CrowdFoundAppTeam3.Interface
{
    public interface IFundingPackage
    {
        public Task<List<FundingPackage?>> GetFundingPackagesByProjectAsync(int projectId);

        public Task<FundingPackageDto> CreateFundingPackageAsync(FundingPackageDto fundingPackagedto, int projectId);
    }
}