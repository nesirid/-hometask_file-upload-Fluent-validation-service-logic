﻿using System.ComponentModel.DataAnnotations;

namespace eLearning.DTOs.SocialInstructors
{
    public class InstructorSocialEditDto
    {
        [Required]
        public string SocialPlatform { get; set; }
        [Required]
        public string Url { get; set; }
    }
}