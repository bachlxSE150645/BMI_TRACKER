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
    [PrimaryKey(nameof(orderId), nameof(serviceId))]
    public class orderDetail
    {
        [ForeignKey("order")]
        public Guid orderId { get; set;}
        [ForeignKey("service")]
        public Guid serviceId { get; set; }
        public string? status { get; set; }
        public int? quantity { get; set; }
        public decimal? unitPrice { get; set; }

        public Order orders { get; set; }
        

        public Service services { get; set; }

    }
}
