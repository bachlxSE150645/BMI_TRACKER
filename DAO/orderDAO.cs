using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class orderDAO
    {
        private readonly MyDbContext _context;
        public orderDAO(MyDbContext context)
        {
            _context = context;
        }
        public async Task <List<Order>> GetOrders()
        {
            try
            {
                return await _context.orders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Order> GetOrdersByName(string name)
        {
            var recipes = new List<Order>();
            try
            {
                recipes = this._context.orders
                    .Include(c => c.payments)
                    .Include(c => c.orderDetails)
                    .Where(x => x.orderName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return recipes;
        }
        public Order GetOrderById(Guid id)
        {
            try
            {
                return _context.orders.SingleOrDefault(x => x.orderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Role
        public Order AddOrder(Order category)
        {
            try
            {
                var newCategory = new Order
                {
                    orderId = Guid.NewGuid(),
                    orderName = category.orderName,
                    orderTitle = category.orderTitle,
                    status = "avaiable"
                   
                };
                _context.orders.Add(newCategory);
                _context.SaveChanges();
                return newCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public Order UpdateOrder(Order order ,Guid id)
        {
            try
            {

               var or = this._context.orders
                     .Include(c => c.payments)
                     .Include(c => c.orderDetails)
                     .Where(x => x.orderId.Equals(id)).SingleOrDefault();
                or.orderName = order.orderName;
                or.orderTitle = order.orderTitle;
                or.status = order.status;
                _context.orders.Update(or);
                _context.SaveChanges();
                return or;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public void DeleteOrder(Order cate)
        {
            try
            {
                var cateCheck = _context.orders.SingleOrDefault(x => x.orderId == cate.orderId);
                if (cateCheck != null)
                {
                    _context.orders .Remove(cateCheck);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
