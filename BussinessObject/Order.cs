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
    public class Order
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid orderId { get; set; }
        public string orderName { get; set; }
        public string orderTitle { get; set; }
        public DateTime? dateCreated { get; set; }
        public string status { get; set; }
        
       
        [JsonIgnore]

        public ICollection <orderDetail> orderDetails { get; set; }
       
        [ForeignKey("payment")]
        public Guid paymentId { get; set; }
        public payment payments { get; set; }
        [ForeignKey("userBoyMax")]
        public Guid userBodyMaxId { get; set; }
        public userBodyMax userBodyMaxs { get; set; }
    }
}
