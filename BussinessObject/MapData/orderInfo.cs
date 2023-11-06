using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class orderInfo
    {
        public string orderName { get; set; }
        public string orderTitle { get; set; }

        public orderDetailsDTO[] orderDetailsDTO { get; set; }

    }
    public class orderDetailsDTO
    {
        public int? quantity { get; set; }
        public decimal? unitPrice { get; set; }
    }
}
