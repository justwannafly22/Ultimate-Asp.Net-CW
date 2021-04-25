using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.ServiceType
{
    public abstract class ServiceTypeForManipulationDto
    {
        [Required(ErrorMessage = "Service type name is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Name is 80 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Description is 100 characters.")]
        public string Description { get; set; }
    }
}
