using System.ComponentModel.DataAnnotations;

namespace eLearning.Models
{
    public class Student : BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Profession { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
        public Student()
        {
            CourseStudents = new();
        }
    }
}
