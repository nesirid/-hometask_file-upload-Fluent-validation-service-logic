using System.ComponentModel.DataAnnotations;

namespace eLearning.Models
{
    public class Slider : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? Image { get; set; }
    }
}
