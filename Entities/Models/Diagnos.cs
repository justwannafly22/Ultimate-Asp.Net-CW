using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Diagnos
    {
        [Column("DiagnosId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Diagnos name is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Name is 80 characters.")]
        public string Name { get; set; }
        
        public DateTime DateOfDiagnosis { get; set; }

        public string Treatment { get; set; }//назначенное лечение
        
        public string CourseOfDisease { get; set; }//течение болезни

        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
