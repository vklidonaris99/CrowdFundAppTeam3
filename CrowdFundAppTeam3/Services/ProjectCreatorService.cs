using CrowdFoundAppTeam3.Data;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CrowdFoundAppTeam3.Services
{
    public class ProjectCreatorService : IProjectCreator
    {
        private readonly CrowdFundDbContext _crowdFundDbContext;

        private readonly ILogger<ProjectCreatorService> _logger;

        public ProjectCreatorService(CrowdFundDbContext context, ILogger<ProjectCreatorService> logger)
        {
            _crowdFundDbContext = context;
            _logger = logger;
        }

        public async Task<ProjectCreatorDto?> CreateProjectCreatorAsync(ProjectCreatorDto projectCreatorDto)
        {
            if (string.IsNullOrWhiteSpace(projectCreatorDto.FirstName) ||
                string.IsNullOrWhiteSpace(projectCreatorDto.LastName) ||
                string.IsNullOrWhiteSpace(projectCreatorDto.Email) ||
                string.IsNullOrWhiteSpace(projectCreatorDto.Password))
            {
                _logger.LogError("Please insert all the parameters");
                return null;
            }

            

            var newprojectCreator = new ProjectCreator()
            {
                FirstName = projectCreatorDto.FirstName,
                LastName = projectCreatorDto.LastName,
                Email = projectCreatorDto.Email,
                Password = projectCreatorDto.Password
            };

            var projectCreatorWithSameEmail = await _crowdFundDbContext.ProjectCreators.SingleOrDefaultAsync(pc => pc.Email == projectCreatorDto.Email);

            if (projectCreatorWithSameEmail != null)
            {
                _logger.LogError("Project Creator with the same email aready exists");
                    return null;
            }


            await _crowdFundDbContext.AddAsync(newprojectCreator);
            await _crowdFundDbContext.SaveChangesAsync();
            return newprojectCreator.ConvertPC();
        }
    }
}
