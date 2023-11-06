using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObject
{
    [PrimaryKey(nameof(userId),nameof(paymentId))]
    public class paymentDetails
    {
        [ForeignKey("user")]
        public Guid userId { get; set; }
        [ForeignKey("payment")]
        public Guid paymentId { get; set; }


        public user users { get; set; }

        public payment payments { get; set; }
    }
}
