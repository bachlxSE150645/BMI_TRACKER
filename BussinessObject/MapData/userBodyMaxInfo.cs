
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
        [Required]
        public int age { get; set; }
        public sexType sex { get; set; }
        public Guid userId { get; set; }
        public Guid serviceId { get; set; }
        public UserBodyMaxMenus[] UserBodyMaxMenus { get; set; }
    }
    public class UserBodyMaxMenus
    {
        public Guid MenuId { get; set; }

    }

}
