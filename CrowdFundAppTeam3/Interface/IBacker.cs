using CrowdFoundAppTeam3.DTOs;

namespace CrowdFoundAppTeam3.Interface
{
    public interface IBacker
    {

        //public Task<BackerDto?> GetBackerAsync(BackerDto backer);

        public Task<BackerDto> CreateBackerAsync(BackerDto backer);

        public Task<List<BackerDto>> GetAllBackerAsync();


    }
}

