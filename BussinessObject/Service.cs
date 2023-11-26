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
    public class Service
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid serviceId {  get; set; }
        public string nameService { get; set; }
        public string descriptionService {  get; set; }
        public string status { get; set; }
        [JsonIgnore]
        public ICollection <userBodyMax> userBodyMaxs { get; set; }
        [JsonIgnore]
        public ICollection<complement> complements { get; set; }
    }

}
