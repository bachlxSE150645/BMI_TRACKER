using BussinessObject;
using BussinessObject.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderRepository
    {
        public List<order> GetAllOrders();
        public order getOrderById(Guid id);
        public order addOrder(order order);
        public order updateOrder(Guid id, updateOrderInfo order);
        public bool deleteOrder(order id);
    }
}