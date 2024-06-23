using eLearning.DTOs.SocialInstructors;
using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Instructors
{
    public class InstructorEditDto
    {
        [Required]
        public string FullName { get; set; }
        public List<IFormFile> Images { get; set; }
        [Required]
        public string Field { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<string> ExistingImages { get; set; } 
        public List<string> ImagesToRemove { get; set; } 
        public List<InstructorSocialDto> InstructorSocials { get; set; }
    }
}
