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
    public class orderDetailRepository :IOrderDetailRepository
    {
        private readonly orderDetailDAO dao;

        public orderDetailRepository(MyDbContext dbContext)
        {
            dao = new orderDetailDAO(dbContext);
        }

        public Task<orderDetail> AddOrderDetail(orderDetail inf) =>dao.AddOrderDetail(inf);

        public void DeleteOrderDetail(orderDetail recipeDetail)=>dao.DeleteOrderDetail(recipeDetail);

        public List<orderDetail> GetordeDetailsByserviceId(Guid serviceId) => dao.GetordeDetailsByserviceId(serviceId);

        public List<orderDetail> GetOrderDetails() =>dao.GetOrderDetails();

        public List<orderDetail> GetRecipeDetailsByOrderId(Guid orderId)=>dao.GetRecipeDetailsByOrderId(orderId);

        public void UpdateOrderDetail(orderDetail recipeDetail)=>dao.UpdateOrderDetail(recipeDetail);
    }
}
