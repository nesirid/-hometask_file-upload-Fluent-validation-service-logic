using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Categories
{
    public class CategoryEditDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public List<IFormFile> Images { get; set; }
        public List<string> ExistingImages { get; set; }
        public List<string> ImagesToRemove { get; set; } = new List<string>();
    }
}
