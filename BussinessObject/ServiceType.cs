using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class ServiceType
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ServiceTypeId { get; set; }
        public string nameServiceType {  get; set; }
        public string textServiceType { get; set; }
        public string status { get; set; }
        public ICollection <Service> services { get; set; }
    }

}
