using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class ScheduleInfo
    {
        public int dateScheduled { get; set; }
        public Guid userInfoId { get; set; }
        public Guid menuId { get; set; }
    }
}
