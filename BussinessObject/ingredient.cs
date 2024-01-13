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
    public class ingredient
    {
      
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ingredientId { get; set; }

        public string ingredientName {  get; set; }
        public string ingredientPhoto { get; set; }
        public string status { get; set; }
        public ICollection<recipe> recipes { get; set; }
        [ForeignKey("category")]
        public Guid  categoryId { get; set; }
        public Category categorys { get; set; }
    }
}
