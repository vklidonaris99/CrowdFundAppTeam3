using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;

namespace CrowdFoundAppTeam3.Interface
{
    public interface IProjectCreator
    {
        public Task<ProjectCreatorDto?> CreateProjectCreatorAsync(ProjectCreatorDto projectCreatorDto);
    }
}
