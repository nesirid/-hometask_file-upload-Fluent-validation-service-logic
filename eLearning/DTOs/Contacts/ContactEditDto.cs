using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.Contacts
{
    public class ContactEditDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
