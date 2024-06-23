using System.ComponentModel.DataAnnotations;

namespace eLearning.Models
{
    public class Course : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<CourseImage> CourseImages { get; set; }
        [Required]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; }
    }
}
