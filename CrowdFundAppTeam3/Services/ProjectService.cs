using CrowdFoundAppTeam3.Data;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

namespace CrowdFoundAppTeam3.Services
{
    public class ProjectService : IProjectService
    {
        private readonly CrowdFundDbContext _crowdFundDbContext;

        public ProjectService(CrowdFundDbContext dbcontext)
        {
            _crowdFundDbContext = dbcontext;
        }

        public async Task<ProjectDto> CreateProjectAsync(ProjectDto projectdto)
        {
            var projectCreator = await _crowdFundDbContext
                .ProjectCreators
                .SingleOrDefaultAsync(pc => pc.ProjectCreatorId == projectdto.ProjectCreator.ProjectCreatorId);

            if (projectCreator == null) return null;

            //ProjectCreator projectcreator = await CrowdFundDbContext.Users.SingleOrDefaultAsync(pc => pc.Id == projectdto.ProjectCreator!.UserId));

            Project project = new Project()
            {
                Title = projectdto.Title,
                Description = projectdto.Description,
                ProjectCategory = projectdto.ProjectCategory,
                ProjectCreator = projectCreator
            };

            _crowdFundDbContext.Projects.Add(project);
            await _crowdFundDbContext.SaveChangesAsync();

            return project.Convert();
        }

        public async Task<List<ProjectDto>> GetAllProjectAsync()
        {
            return await _crowdFundDbContext.Projects
           .Include(project => project.ProjectCreator)
           .Select(project => project.Convert())
           .ToListAsync();
        }

        public async Task<ProjectDto?> GetProjectByCategoryAsync(ProjectCategory projectCategory)
        {
            var project = await _crowdFundDbContext.Projects
                //.Include(project => project.ProjectCategory)
                .SingleOrDefaultAsync(project => project.ProjectCategory == projectCategory);

            return project?.Convert();

        }

        public async Task<List<ProjectDto>> SearchAsync
            ([FromQuery] string Title, [FromQuery] string Description)
        {
            var results = _crowdFundDbContext.Projects.Include(pc => pc.ProjectCreator).Select(p => p);

            if (Title != null)
            {
                results = results.Where(p => p.Title.ToLower().Contains(Title.ToLower()));

            }
            else if (Description != null)
            {
                results = results.Where(p => p.Description.ToLower().Contains(Description.ToLower()));
            }
            else
            {
                return null;
            }

            var resultsList = await results.ToListAsync();

            if (resultsList == null) return null;

            List<ProjectDto> response = new();
            foreach (var p in resultsList)
            {
                response.Add(p.Convert());
            }

            return response;
        }



        public async Task<ProjectDtoFlat> UpdateAsync(int projectId, ProjectDtoFlat projectDtoFlat)
        {
            Project? project = await _crowdFundDbContext.Projects
                 .Include(project => project.ProjectCreator)
                 .SingleOrDefaultAsync(project => project.ProjectId == projectId);

            // if (project is null) throw new NotFoundException("The project id is invalid or the project has been removed.");

            if (projectDtoFlat.Title is not null) project.Title = projectDtoFlat.Title;

            if (projectDtoFlat.Description is not null) project.Description = projectDtoFlat.Description;

            project.ProjectCategory = projectDtoFlat.ProjectCategory;

            //if (projectdto.ProjectCreator is not null)
            //{
            //    var projectCreator = _crowdFundDbContext.ProjectCreators.SingleOrDefault(pc => pc.ProjectCreatorId == projectdto.ProjectCreator.ProjectCreatorId);
            //    if (projectCreator is not null) project.ProjectCreator = projectCreator;
            //}

            await _crowdFundDbContext.SaveChangesAsync();

            return project.ConvertPDtoFlat();
        }

        public async Task<List<Project>> GetMostFundedProjectsAsync()
        {
            var max = new float();
            max = 0;
            var return_project_list = new List<Project>();
            var project_list = await _crowdFundDbContext.Projects.Include(project => project.FundingPackages).ToListAsync();

            //Get Max Current Funds
            if (project_list == null)
            {
                return null;
            }

            foreach (var project in project_list)
            {
                if (project.CurrentFunds >= max)
                {
                    max = project.CurrentFunds;
                    return_project_list.Add(project);
                }
            }

            return_project_list.Reverse();

            if (return_project_list.Count > 2)
            {
                return_project_list.RemoveRange(2, return_project_list.Count - 2);
            }

            return return_project_list;
        }
    }
}
