using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class orderDetailDAO
    {
        private readonly MyDbContext _context;
        public orderDetailDAO(MyDbContext context) { _context = context; }

        public List<orderDetail> GetOrderDetails()
        {
            try
            {
                return _context.orderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<orderDetail> GetRecipeDetailsByOrderId(Guid orderId)
        {
            try
            {
                return _context.orderDetails
                    .Where(x => Guid.Equals(x.orderId, orderId))
                    .Include(c => c.orders)
                    .Include(c => c.services).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<orderDetail> GetordeDetailsByserviceId(Guid serviceId)
        {
            try
            {
                return _context.orderDetails.Where(x => x.services.serviceId == serviceId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<orderDetail> AddOrderDetail(orderDetail inf)
        {
            try
            {
                _context.orderDetails.Add(inf);
                await _context.SaveChangesAsync();
                return inf;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateOrderDetail(orderDetail recipeDetail)
        {
            try
            {
                var recipeDetailCheck = _context.orderDetails.SingleOrDefault(x => x.orderId == recipeDetail.orderId && x.serviceId == recipeDetail.serviceId);
                if (recipeDetailCheck != null)
                {
                    _context.Entry(recipeDetailCheck).CurrentValues.SetValues(recipeDetail);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Recipe Detail
        public void DeleteOrderDetail(orderDetail recipeDetail)
        {
            try
            {
                var recipeDetailCheck = _context.orderDetails.SingleOrDefault(x => x.orderId == recipeDetail.orderId && x.serviceId == recipeDetail.serviceId);
                if (recipeDetailCheck != null)
                {
                    _context.orderDetails.Remove(recipeDetailCheck);
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
