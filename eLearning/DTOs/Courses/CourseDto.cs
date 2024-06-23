namespace eLearning.DTOs.Courses
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
