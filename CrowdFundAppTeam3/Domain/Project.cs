
namespace CrowdFoundAppTeam3.Domain
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? VideoPath { get; set; }

        public string? PhotoPath { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ProjectCategory ProjectCategory { get; set; }

        public List<FundingPackage>? FundingPackages { get; set; }

        public List<Backer>? Backers { get; set; }

        public ProjectCreator? ProjectCreator { get; set; }

        public float CurrentFunds { get; set; } //decimal
    }
}
