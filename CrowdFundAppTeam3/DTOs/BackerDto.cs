using CrowdFoundAppTeam3.DTOs;

namespace CrowdFoundAppTeam3.DTOs
{
    public class BackerDto
    {
        public List<ProjectDto>? Projects { get; set; }

        public int BackerId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}

