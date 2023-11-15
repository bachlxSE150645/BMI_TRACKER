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
    public class Menu
    {
          
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MenuId { get; set; }
        
        public string menuName { get; set; }
        public string menuDescription { get; set; }
        public string menuPrice { get; set; }
        public string menuType { get; set; }
        
        public string menuPhoto { get; set; }
        [ForeignKey("category")]
        public Guid categoryId { get; set; }
        public Category categorys { get; set; }
        public string status { get; set; }
        [JsonIgnore]

        public ICollection<Schedule> schedules { get; set; }
        [JsonIgnore]

        public ICollection<Meal> meals { get; set; }
        
    }
}
