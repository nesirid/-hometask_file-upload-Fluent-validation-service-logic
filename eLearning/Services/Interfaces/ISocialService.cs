using eLearning.DTOs.Socials;

namespace eLearning.Services.Interfaces
{
    public interface ISocialService
    {
        Task<IEnumerable<SocialDto>> GetAllAsync();
        Task<SocialDto> GetByIdAsync(int id);
        Task<SocialDto> CreateAsync(SocialCreateDto socialCreateDto);
        Task UpdateAsync(int id, SocialEditDto socialEditDto);
        Task DeleteAsync(int id);
    }
}
