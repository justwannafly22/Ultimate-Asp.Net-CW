using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestFeatures
{
    public class PatientParameters : BasicParameters
    {
        public uint MinAge { get; set; }
        public uint MaxAge { get; set; } = int.MaxValue;

        public bool ValidAgeRange => MaxAge > MinAge;
    }
}
