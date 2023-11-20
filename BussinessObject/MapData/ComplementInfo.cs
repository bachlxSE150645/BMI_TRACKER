using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class ComplementInfo
    {
        public Guid ratingId { get; set; }
        public int quantity { get; set; }       
        public Guid userId { get; set; }  
        public Guid serviceId { get; set; }
        public Guid blogId { get; set; }
       
    }
}
