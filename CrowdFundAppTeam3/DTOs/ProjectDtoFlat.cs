using CrowdFoundAppTeam3.Domain;

namespace CrowdFoundAppTeam3.DTOs
{
    public class ProjectDtoFlat
    {
        public int ProjectId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public ProjectCategory ProjectCategory { get; set; }

    }
}
