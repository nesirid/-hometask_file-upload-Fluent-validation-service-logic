﻿using System.ComponentModel.DataAnnotations;

namespace eLearning.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
