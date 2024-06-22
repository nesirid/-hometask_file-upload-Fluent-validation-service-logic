using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Sliders
{
    public class SliderCreateDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public List<IFormFile> Images { get; set; }
    }

}
