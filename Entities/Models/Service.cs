using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Service
    {
        [Column("ServiceId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Attendance name is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Name is 80 characters.")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price is required and can`t be lower than 0.")]
        public double Price { get; set; }

        [ForeignKey(nameof(ServiceType))]
        public Guid? ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}
