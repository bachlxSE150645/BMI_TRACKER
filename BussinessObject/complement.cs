using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class complement
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ratingId { get; set; }
        public string status { get; set; }
        public int quantity { get; set; }
        [ForeignKey("user")]
        public Guid userId { get; set; }
        public user users { get; set; }
        [ForeignKey("service")]
        public Guid serviceId { get; set; }
        public Service services { get; set; }
        [ForeignKey("blog")]
        public Guid blogId { get; set; }
        public blog blogs { get; set; }
    }
}
