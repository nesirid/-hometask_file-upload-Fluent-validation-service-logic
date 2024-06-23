using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Socials
{
    public class SocialEditDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}
