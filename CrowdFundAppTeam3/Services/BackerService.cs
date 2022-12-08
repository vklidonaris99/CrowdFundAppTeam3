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

        public async Task<BackerDtoFlat?> CreateBackerAsync(BackerDtoFlat backerDto)
        {
            if (string.IsNullOrWhiteSpace(backerDto.FirstName) ||
                string.IsNullOrWhiteSpace(backerDto.LastName) ||
                string.IsNullOrWhiteSpace(backerDto.Email) ||
                string.IsNullOrWhiteSpace(backerDto.Password))
            {
                _logger.LogError("Please insert all the parameters");
                return null;
            }

            var newBacker = new Backer()
            {
                FirstName = backerDto.FirstName,
                LastName = backerDto.LastName,
                Email = backerDto.Email,
                Password = backerDto.Password
            };


            var backerWithSameEmail = await _crowdFundDbContext.Backers.SingleOrDefaultAsync(b => b.Email == backerDto.Email);

            if (backerWithSameEmail != null)
            {
                _logger.LogError("Backer with the same email aready exists");
                return null;
            }

            await _crowdFundDbContext.AddAsync(newBacker);
            await _crowdFundDbContext.SaveChangesAsync();
            return newBacker.ConvertBackerFlat();
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

