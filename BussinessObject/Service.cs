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
        [ForeignKey("user")]
        public Guid userId { get; set; }
        public user users { get; set; }

        [JsonIgnore]
        public ICollection <order> orders { get; set; }
        [JsonIgnore]
        public ICollection<trackForm> trackForms { get; set; }

    }

}
