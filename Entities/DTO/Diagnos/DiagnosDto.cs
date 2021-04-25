using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Diagnos
{
    public class DiagnosDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfDiagnosis { get; set; }
        public string Treatment { get; set; }//назначенное лечение
        public string CourseOfDisease { get; set; }//течение болезни
    }
}
