using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{

    [PrimaryKey(nameof(userInfoId), nameof(serviceId),nameof(orderId))]
    public class order
    {
        public Guid orderId { get; set; } 
        public string orderName { get; set; }
        public string orderDescription { get; set; }
        public string orderStatus { get; set; }
        public decimal orderPrice { get; set; }
        public DateTime orderDate { get; set; }
        [ForeignKey("userBodyMax")]
        public Guid userInfoId { get; set; }
        public userBodyMax userBodyMaxs{ get; set; }
        [ForeignKey("Service")]
        public Guid serviceId { get; set; }
        public Service services { get; set; }
    }
}
