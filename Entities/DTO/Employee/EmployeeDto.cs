﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Employee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Speciality { get; set; }
    }
}
