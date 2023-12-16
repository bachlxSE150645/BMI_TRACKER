using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class OrderInfo
    {
        public string orderName { get; set; }
        public string orderDescription { get; set; }
        public decimal orderPrice { get; set; }
        public Guid userInfoId { get; set; }
        public Guid serviceId { get; set; }
    }
    public class updateOrderInfo
    {
        public string orderName { get; set; }
        public string orderDescription { get; set; }
        public decimal orderPrice { get; set; }
    }
}
