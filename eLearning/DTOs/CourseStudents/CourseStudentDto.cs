using eLearning.DTOs.Courses;
using eLearning.DTOs.Students;

namespace eLearning.DTOs.CourseStudents
{
    public class CourseStudentDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public CourseDto Course { get; set; }
        public StudentDto Student { get; set; }
    }
}
