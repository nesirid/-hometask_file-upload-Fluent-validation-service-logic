using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Categories
{
    public class CategoryCreateDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
