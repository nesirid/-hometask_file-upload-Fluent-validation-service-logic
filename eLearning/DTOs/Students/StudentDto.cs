using eLearning.DTOs.CourseStudents;

namespace eLearning.DTOs.Students
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Profession { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<CourseStudentDto> CourseStudents { get; set; }
    }
}
