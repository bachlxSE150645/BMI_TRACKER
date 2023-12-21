using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class trackformInfo
    {
        public string trackFormName { get; set; }
        public string trackeFormDescription { get; set; }
        public Guid serviceId { get; set; }
        public Guid userId { get; set; }
       
    }
    public class trackFormUpdateInfo
    {
        public string trackFormName { get; set; }
        public string trackeFormDescription { get; set; }
    }
   
}
