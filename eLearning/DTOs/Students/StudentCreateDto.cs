using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Students
{
    public class StudentCreateDto
    {
        [Required]
        public string FullName { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Description { get; set; }
        public string Profession { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
