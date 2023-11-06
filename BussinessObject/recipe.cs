
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObject
{
    [PrimaryKey(nameof(ingredientId), nameof(foodId))]
    public class recipe
    {
        [ForeignKey("Ingredient")]
        public Guid ingredientId { get; set; }
        [ForeignKey("food")]
        public Guid foodId { get; set; }

        public food foods { get; set; }
        public  ingredient ingredients { get; set; }

    }
}
