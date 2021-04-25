using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Service
{
    public abstract class ServiceForManipulationDto
    {
        [Required(ErrorMessage = "Attendance name is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Name is 80 characters.")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price is required and can`t be lower than 0.")]
        public double Price { get; set; }
    }
}
