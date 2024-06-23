using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Socials
{
    public class SocialCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}
