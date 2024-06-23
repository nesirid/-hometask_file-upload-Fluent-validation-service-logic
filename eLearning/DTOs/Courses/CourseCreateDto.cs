using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Courses
{
    public class CourseCreateDto
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
        [Required]
        public int InstructorId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
