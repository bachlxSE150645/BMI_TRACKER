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
        public string createBy { get; set; }
        public string status { get; set; }
        
        [JsonIgnore]
        public ICollection <complement> complements { get; set; }
        [JsonIgnore]
        public ICollection<Content> contents { get; set; }
       
    }
}
