using eLearning.DTOs.SocialInstructors;

namespace eLearning.DTOs.Instructors
{
    public class InstructorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Field { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<InstructorSocialDto> InstructorSocials { get; set; }
    }
}
