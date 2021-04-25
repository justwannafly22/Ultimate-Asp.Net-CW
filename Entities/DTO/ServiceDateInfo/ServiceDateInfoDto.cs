using System;
using System.Collections.Generic;

namespace Entities.DTO.ServiceDateInfo
{
    public class ServiceDateInfoDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
