using CrowdFoundAppTeam3.Data;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using Microsoft.EntityFrameworkCore;

namespace CrowdFoundAppTeam3.Services
{
    public class BackerService : IBacker
    {
        private readonly CrowdFundDbContext _crowdFundDbContext;

        private readonly ILogger<BackerService> _logger;

        public BackerService(CrowdFundDbContext context, ILogger<BackerService> logger)
        {
            _crowdFundDbContext = context;
            _logger = logger;
        }

        public async Task<BackerDto?> CreateBackerAsync(BackerDto BackerDto)
        {
            if (string.IsNullOrWhiteSpace(BackerDto.FirstName) ||
                string.IsNullOrWhiteSpace(BackerDto.LastName) ||
                string.IsNullOrWhiteSpace(BackerDto.Email))
            {
                _logger.LogError("Please insert all the parameters");
                return null; ;
            }

            var newBacker = new Backer()
            {
                FirstName = BackerDto.FirstName,
                LastName = BackerDto.LastName,
                Email = BackerDto.Email
            };

            await _crowdFundDbContext.AddAsync(newBacker);
            await _crowdFundDbContext.SaveChangesAsync();
            return newBacker.ConvertBacker();
        }

        public async Task<List<BackerDto>> GetAllBackerAsync()
        {
            return await _crowdFundDbContext.Backers
                .Include(backer => backer.BackerId)
                .Select(backer => backer.ConvertBacker())
                .ToListAsync();
        }
    }
}

