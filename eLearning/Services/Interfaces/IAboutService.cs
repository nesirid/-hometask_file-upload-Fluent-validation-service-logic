using eLearning.DTOs.Abouts;

namespace eLearning.Services.Interfaces
{
    public interface IAboutService
    {
        Task<IEnumerable<AboutDto>> GetAllAsync();
        Task<AboutDto> GetByIdAsync(int id);
        Task CreateAsync(AboutCreateDto aboutCreateDto);
        Task UpdateAsync(int id, AboutDto aboutDto);
        Task DeleteAsync(int id);
    }
}
