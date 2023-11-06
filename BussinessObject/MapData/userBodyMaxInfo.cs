
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class userBodyMaxInfo
    {
        [Required]
        public int heght { get; set; }
        [Required]
        public int weight { get; set; }
        public int minimum_calories { get; set; }
        public int maximum_calories { get; set; }
        public string photo { get; set; }
        public float BMIPerson { get; set; }
        [Required]
        public int age { get; set; }
    }
}
