using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class MenuInfo
    {
        public string menuName { get; set; }
        public string menuDescription { get; set; }
        public string menuPrice { get; set; }
        public string menuType { get; set; }
        public string menuPhoto { get; set; }
        public foodMenuDTO[] foods { get; set; }
    }
    public class foodMenuDTO
    {
        public Guid foodId { get; set; }
    }

}
