using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Diagnos
{
    public abstract class DiagnosForManipulationDto
    {
        [Required(ErrorMessage = "Diagnos name is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Name is 80 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of diagnosis is a required field.")]
        public DateTime DateOfDiagnosis { get; set; }

        [Required(ErrorMessage = "Diagnos name is a required field.")]
        public string Treatment { get; set; }//назначенное лечение

        [Required(ErrorMessage = "Diagnos name is a required field.")]
        public string CourseOfDisease { get; set; }//течение болезни
    }
}
