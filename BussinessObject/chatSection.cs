using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [PrimaryKey(nameof(userId), nameof(messageId))]
    public class chatSection
    {

        [ForeignKey("user")]
        public Guid userId { get; set; }
        [ForeignKey("message")]
        public Guid messageId { get; set; }
        public user users { get; set; }
        public message messages { get; set; }
    }
}
