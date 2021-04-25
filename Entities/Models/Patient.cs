using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Patient
    {
        [Column("PatientId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Patient name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Age is required and it can`t be lower than 0.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Patient description is a required field.")]
        [MaxLength(300, ErrorMessage = "Max length for the Description is 300 characters.")]
        public string Description { get; set; }
        
        public ICollection<Diagnos> Diagnoses { get; set; }

        [ForeignKey(nameof(ServiceDateInfo))]
        public Guid? ServiceDateInfoId { get; set; }
        public ServiceDateInfo ServiceDateInfo { get; set; }
    }
}
