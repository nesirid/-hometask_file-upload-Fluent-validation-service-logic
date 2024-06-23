using System.ComponentModel.DataAnnotations;

namespace eLearning.Models
{
    public class Instructor : BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        public string Image { get; set; }
        [Required]
        public string Field { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<InstructorSocial> InstructorSocials { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
