using BussinessObject;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository :IOrderRepository
    {
        private readonly orderDAO dao;

        public OrderRepository(MyDbContext dbContext)
        {
            dao = new orderDAO(dbContext);
        }

        public Order AddOrder(Order category)=>dao.AddOrder(category);

        public void DeleteOrder(Order cate)=>dao.DeleteOrder(cate);

        public Order GetOrderById(Guid id)=>dao.GetOrderById(id);

        public Task<List<Order>> GetOrders() =>dao.GetOrders();

        public List<Order> GetOrdersByName(string name) =>dao.GetOrdersByName(name);

        public Order UpdateOrder(Order order, Guid id) =>dao.UpdateOrder(order, id);
    }
}
