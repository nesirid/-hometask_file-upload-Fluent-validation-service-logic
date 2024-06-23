using eLearning.DTOs.Courses;

namespace eLearning.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto> GetByIdAsync(int id);
        Task CreateAsync(CourseCreateDto courseCreateDto);
        Task UpdateAsync(int id, CourseEditDto courseEditDto);
        Task DeleteAsync(int id);
    }
}
