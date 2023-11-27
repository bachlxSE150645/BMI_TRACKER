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
    public class complementBlog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid complementBlogId { get; set; }
        public string status { get; set; }
        public int quantity { get; set; }
        [ForeignKey("user")]
        public Guid userId { get; set; }
        public user users { get; set; }
        
        [ForeignKey("blog")]
        public Guid blogId { get; set; }
        public blog blogs { get; set; }
    }
}
