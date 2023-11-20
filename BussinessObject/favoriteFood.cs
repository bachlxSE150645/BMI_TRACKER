using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [PrimaryKey(nameof(foodId), nameof(userId))]
    public class favoriteFood
    {
        [ForeignKey("food")]
        public Guid foodId { get; set; }
        [ForeignKey("user")]
        public Guid userId { get; set; }
        public food foods { get; set; }
        public user users { get; set; }
    }
    
}
