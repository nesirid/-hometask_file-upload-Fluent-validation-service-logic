using eLearning.DTOs.Courses;

namespace eLearning.DTOs.Categories
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<CourseDto> Courses { get; set; }
    }
}
