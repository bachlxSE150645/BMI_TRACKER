using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [PrimaryKey(nameof(menuId), nameof(foodId))]

    public class Meal
    {
        [ForeignKey("food")]
        public Guid menuId { get; set; }
        [ForeignKey("Menu")]
        public Guid foodId { get; set; }

        public food foods { get; set; }
        public Menu Menus { get; set; }
    }
}
