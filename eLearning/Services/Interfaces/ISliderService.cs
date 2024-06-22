using eLearning.DTOs.Sliders;

namespace eLearning.Services.Interfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderDto>> GetAllAsync();
        Task<SliderDto> GetByIdAsync(int id);
        Task CreateAsync(SliderDto sliderDto);
        Task UpdateAsync(int id, SliderDto sliderDto);
        Task DeleteAsync(int id);
    }
}
