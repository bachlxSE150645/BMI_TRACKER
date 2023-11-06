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
    public class feebackCategory
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid feedbackCategoryId { get; set; }
        public string feedbackCategoryName { get; set; }
        public string status { get; set; }
        public string createBy { get; set; }
        public DateTime createTime { get; set; }
        public string updateBy { get; set; }
        public DateTime updateTime { get; set; }

        public ICollection<feedback> feedbacks { get; set; }
    }
}
