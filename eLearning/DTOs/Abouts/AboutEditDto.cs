using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Abouts
{
    public class AboutEditDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<string>? ExistingImages { get; set; }
        public List<string>? ImagesToRemove { get; set; }
    }
}
