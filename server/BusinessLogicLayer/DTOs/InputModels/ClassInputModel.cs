﻿using System.ComponentModel.DataAnnotations;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class ClassInputModel
    {
        [Required]
        public int StartYear { get; set; }
        
        [Required]
        [Range(1,12)]
        public int Grade { get; set; }
        
        [Required]
        [StringLength(1)]
        public char GradeLetter { get; set; }
    }
}