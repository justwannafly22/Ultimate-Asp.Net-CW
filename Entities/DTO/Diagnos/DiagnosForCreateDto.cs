using System;
using System.Collections.Generic;

namespace Entities.DTO.Diagnos
{
    public class DiagnosForCreateDto : DiagnosForManipulationDto
    {
        public Guid? ServiceDateInfoId { get; set; }
    }
}
