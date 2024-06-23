using eLearning.DTOs.InformationIcons;

namespace eLearning.Services.Interfaces
{
    public interface IInformationIconService 
    {
        Task<IEnumerable<InformationIconDto>> GetAllAsync();
        Task<InformationIconDto> GetByIdAsync(int id);
        Task CreateAsync(InformationIconCreateDto informationIconCreateDto);
        Task UpdateAsync(int id, InformationIconEditDto informationIconEditDto);
        Task DeleteAsync(int id);
    }
}
