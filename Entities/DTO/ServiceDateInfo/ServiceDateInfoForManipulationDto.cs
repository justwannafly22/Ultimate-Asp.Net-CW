using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.ServiceDateInfo
{
    public abstract class ServiceDateInfoForManipulationDto
    {
        [Required(ErrorMessage = "Service date is a required field.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Service description is a required field.")]
        [MaxLength(120, ErrorMessage = "Max length for the Description is 120 characters.")]
        public string Description { get; set; }
    }
}
