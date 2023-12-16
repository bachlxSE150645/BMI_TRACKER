using BussinessObject;
using BussinessObject.MapData;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class orderRepository : IOrderRepository
    {
        private readonly orderDAO dao;

        public orderRepository(MyDbContext dbContext)
        {
            dao = new orderDAO(dbContext);
        }

        public order addOrder(order order)=>dao.addOrder(order);

        public bool deleteOrder(order id) => dao.DeleteOrder(id);

        public List<order> GetAllOrders() =>dao.GetAllOrders();
        public order getOrderById(Guid id) =>dao.getOrderById(id);

        public order updateOrder(Guid id, updateOrderInfo order)
        {
            var o = dao.getOrderById(id);
            if(order.orderName != null)
            {
                o.orderName = order.orderName;
            }
            if(order.orderPrice != null)
            {
                o.orderPrice = order.orderPrice;
            }
            if(order.orderDescription != null)
            {
                o.orderDescription = order.orderDescription;
            }
            return dao.updateOrder(id, o);
        }
    }
}
