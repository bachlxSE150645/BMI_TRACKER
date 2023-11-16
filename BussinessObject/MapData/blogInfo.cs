using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class blogInfo
    {
        public string blogName { get; set; }
        public string blogContent { get; set; }
        public string blogPhoto { get; set; }
        public string link { get; set; }
        public string tag { get; set; }
        public Guid userId { get; set; }
    }
}
