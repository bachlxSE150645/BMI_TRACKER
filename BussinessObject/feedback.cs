using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class feedback
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid feedbackId { get; set; }
        public  string title { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string type { get; set; }

        [ForeignKey("user")]
        public Guid userId { get;set; }
        public user users { get; set; }

    }
    
}
