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
    public class blog
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid bolgId { get; set; }    
        public string blogName { get; set; } 
        public string blogContent { get; set; }
        public string blogPhoto { get; set; }
        public string link { get; set; }
        public string tag { get; set; }
        public DateTime dateTime { get; set; }
       
        public string status { get; set; }
        [ForeignKey("user")]
        public Guid userId { get; set; }
        public user users { get; set; }

        
    }
}
