using System;
using System.Collections.Generic;

namespace Entities.DTO.Patient
{
    public class PatientForUpdateDto : PatientForManipulationDto
    {
        public Guid? ServiceDateInfoId { get; set; }
    }
}
