using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Employee
{
    public abstract class EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Name is 80 characters.")]
        public string Name { get; set; }

        [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can`t be lower than 18")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Employee speciality is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Speciality is 80 characters.")]
        public string Speciality { get; set; }
    }
}
