
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
        public float heght { get; set; }
        [Required]
        public float weight { get; set; }
        [Required]
        public int age { get; set; }
        public sexType sex { get; set; }
        public Guid userId { get; set; }
        public userBodyMaxMenus[] userBodyMaxMenus { get; set; }
    }
    public class userBodyMaxMenus
    {
        public Guid menuId { get; set; }
    }
    public class userBodyMaxUpdateInfo
    {
        [Required]
        public float heght { get; set; }
        [Required]
        public float weight { get; set; }
        [Required]
        public int age { get; set; }
         public userBodyMaxMenus[] userBodyMaxMenus { get; set; }
    }
}
