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
        public string status { get; set; }


        [JsonIgnore]
        public ICollection< food> foods { get; set; }
        [JsonIgnore]
        public ICollection<ingredient> ingredients { get; set; }
        [JsonIgnore]
        public ICollection< Menu> menus { get; set; }


    }
}
