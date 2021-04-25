using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ServiceType
    {
        [Column("TypeServiceId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Service type name is a required field.")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Name is 80 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Description is 100 characters.")]
        public string Description { get; set; }

        [ForeignKey(nameof(ServiceDateInfo))]
        public Guid? ServiceDateInfoId { get; set; }
        public ServiceDateInfo ServiceDateInfo { get; set; }
        
        public ICollection<Service> Services { get; set; }
    }
}
