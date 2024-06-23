using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eLearning.Models
{
    public class InstructorSocial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SocialPlatform { get; set; }
        [Required]
        public string Url { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
