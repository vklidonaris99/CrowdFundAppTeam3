
namespace CrowdFoundAppTeam3.Domain
{
    public class ProjectCreator
    {
        public int ProjectCreatorId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public List<Project>? Projects { get; set; }
    }
}


