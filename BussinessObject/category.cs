using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId {  get; set; }
        public string? CategoryName { get; set; }
        public string createBy { get; set; }
        public string status { get; set; }
        public DateTime? createTime { get; set; }
        public string? updateBy { get; set; }
        public DateTime? updateTime { get; set; }


        public ICollection< food> foods { get; set; }

        public ICollection<ingredient> ingredients { get; set; }

        public ICollection< Menu> menus { get; set; }


    }
}
