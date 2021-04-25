using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Calendar
    {
        [Column("CalendarId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date is a required field.")]
        public DateTime Date { get; set; }

        public ICollection<ServiceDateInfo> ServiceDatesInfo { get; set; }
    }
}
