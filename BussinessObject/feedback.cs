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

        [ForeignKey("feedbackCategory")]
        public Guid feebackCategoryId { get; set; }
        public  string title { get; set; }
        public string description { get; set; }
        
       
        public string status { get; set; }
        public string createBy { get; set; }
        public DateTime createTime { get; set; }
        public string updateBy { get; set; }
        public DateTime updateTime { get; set; }

        [JsonIgnore]
        public feebackCategory feebackCategorys { get; set; }

        [ForeignKey("user")]
        public Guid userId { get;set; }
        public user users { get; set; }

    }
    
}
