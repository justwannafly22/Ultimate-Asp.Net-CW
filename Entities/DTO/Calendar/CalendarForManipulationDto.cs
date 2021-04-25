using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Calendar
{
    public abstract class CalendarForManipulationDto
    {
        [Required(ErrorMessage = "Date is a required field.")]
        public DateTime Date { get; set; }
    }
}
