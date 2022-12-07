using CrowdFoundAppTeam3.Domain;
using CrowdFundAppTeam3.DTOs;

namespace CrowdFoundAppTeam3.DTOs
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        //  public int ProjectCreatorId { get; set; }

        public ProjectCategory ProjectCategory { get; set; }

        public List<BackerDto>? Backers { get; set; }

        public ProjectCreatorDto? ProjectCreator { get; set; }

        public List<FundingPackageDto>? FundingPackages { get; set; }

        public float CurrentFunds { get; set; }
    }
}
