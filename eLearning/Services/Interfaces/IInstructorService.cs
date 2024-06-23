using eLearning.DTOs.Instructors;

namespace eLearning.Services.Interfaces
{
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorDto>> GetAllAsync();
        Task<InstructorDto> GetByIdAsync(int id);
        Task CreateAsync(InstructorCreateDto instructorCreateDto);
        Task UpdateAsync(int id, InstructorEditDto instructorEditDto);
        Task DeleteAsync(int id);
    }
}
