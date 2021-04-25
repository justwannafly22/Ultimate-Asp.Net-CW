using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ServiceDateInfo
    {
        [Column("ServiceDateInfoId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Service date is a required field.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Service description is a required field.")]
        [MaxLength(120, ErrorMessage = "Max length for the Description is 120 characters.")]
        public string Description { get; set; }


        [ForeignKey(nameof(Patient))]
        public Guid? PatientId { get; set; }
        public Patient Patient { get; set; }


        [ForeignKey(nameof(Calendar))]
        public Guid CalendarId { get; set; }
        public Calendar Calendar { get; set; }
        
        public ICollection<ServiceType> ServiceTypes { get; set; }
    }
}
