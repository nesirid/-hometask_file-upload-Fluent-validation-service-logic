using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.InformationIcons
{
    public class InformationIconEditDto
    {
        [Required]
        public string Name { get; set; }
    }
}
