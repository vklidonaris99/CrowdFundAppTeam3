
namespace CrowdFoundAppTeam3.Domain
{
    public class FundingPackage
    {
        public int FundingPackageId { get; set; }

        public string? FundingPackageTitle { get; set; }

        public string? FundingPackageDescription { get; set; }

        public string? RewardPackage { get; set; }

        public Project? Project { get; set; }
    }
}
