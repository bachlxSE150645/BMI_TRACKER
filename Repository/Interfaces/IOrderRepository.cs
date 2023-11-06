using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        List<Order> GetOrdersByName(string name);
        Order GetOrderById(Guid id);
        Order AddOrder(Order category);
        Order UpdateOrder(Order order, Guid id);
        void DeleteOrder(Order cate);

    }
}
