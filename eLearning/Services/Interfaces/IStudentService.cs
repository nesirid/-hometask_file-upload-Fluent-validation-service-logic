using eLearning.DTOs.Students;

namespace eLearning.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(int id);
        Task CreateAsync(StudentCreateDto studentCreateDto);
        Task UpdateAsync(int id, StudentEditDto studentEditDto);
        Task DeleteAsync(int id);
    }
}
