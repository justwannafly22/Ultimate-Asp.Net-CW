using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Name is 80 characters.")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Age is required and it can`t be lower than 0.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Employee speciality is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Speciality is 80 characters.")]
        public string Speciality { get; set; }

        [ForeignKey(nameof(Service))]
        public Guid? ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
