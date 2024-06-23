using eLearning.DTOs.Categories;

namespace eLearning.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateDto categoryCreateDto);
        Task UpdateAsync(int id, CategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}
