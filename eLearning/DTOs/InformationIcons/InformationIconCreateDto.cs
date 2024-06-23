using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.InformationIcons
{
    public class InformationIconCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
