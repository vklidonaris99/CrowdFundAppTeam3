using CrowdFoundAppTeam3.Domain;

namespace CrowdFoundAppTeam3.DTOs
{
    public class FundingPackageDto
    {
        public string? FundingPackageTitle { get; set; }

        public string? FundingPackageDescription { get; set; }

        public string? RewardPackage { get; set; }

        public int ProjectId { get; set; }

    }
}
