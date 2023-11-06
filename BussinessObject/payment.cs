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
    public class payment
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid paymentId {  get; set; }
        public string paymentName { get; set; }
        public string status { get; set; }
        [JsonIgnore]

        public ICollection<paymentDetails> paymentDetails { get; set; }
        [JsonIgnore]
        public Order order { get; set; }
    }
}
