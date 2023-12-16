
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
        public orderDAO(MyDbContext context) { _context = context; }

        public List<order> GetAllOrders()
        {
            try
            {
                return _context.orders.Include(u => u.services).Include(u=>u.userBodyMaxs).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public order getOrderById(Guid id)
        {
            try
            {
                return _context.orders.Where(b => b.orderId == id).Include(u => u.services).Include(u => u.userBodyMaxs).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public order addOrder(order order)
        {
            try
            {
                var NewOrder = new order
                {
                    orderId = Guid.NewGuid(),
                    orderName = order.orderName,
                    orderDate= DateTime.Now,
                    orderDescription = order.orderDescription,
                    orderPrice = order.orderPrice,
                    orderStatus = "avaiable-order",
                    serviceId = order.serviceId,
                    userInfoId = order.userInfoId,
                    services = _context.services.Where(s=>s.serviceId == order.serviceId).FirstOrDefault(),
                    userBodyMaxs = _context.userBodyMaxes.Where(s => s.userInfoId == order.userInfoId).FirstOrDefault(),


                };

                _context.orders.Add(NewOrder);
                _context.SaveChanges();
                return NewOrder;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public order updateOrder(Guid id, order order)
        {

            try
            {
                var or = _context.orders.Where(b => b.orderId.Equals(id))
                    .Include(u => u.services).
                    Include(u => u.userBodyMaxs).FirstOrDefault();
                or.orderName = order.orderName;
                or.orderDescription = order.orderDescription;
                or.orderPrice = order.orderPrice;
                _context.orders.Update(or);
                _context.SaveChanges();
                return or;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteOrder(order feedback)
        {
            try
            {
                var check = _context.orders.SingleOrDefault(f => f.orderId == feedback.orderId);
                if (check != null)
                {
                    _context.orders.Remove(check);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        
    }
}
