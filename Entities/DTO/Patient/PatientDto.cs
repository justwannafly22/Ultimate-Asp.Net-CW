using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Patient
{
    public class PatientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
    }
}
