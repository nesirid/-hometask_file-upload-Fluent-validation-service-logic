using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Abouts
{
    public class AboutCreateDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
