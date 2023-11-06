using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderDetailRepository
    {
        List<orderDetail> GetOrderDetails();
        List<orderDetail> GetRecipeDetailsByOrderId(Guid orderId);
        List<orderDetail> GetordeDetailsByserviceId(Guid serviceId);
        Task<orderDetail> AddOrderDetail(orderDetail inf);
        void UpdateOrderDetail(orderDetail recipeDetail);
        void DeleteOrderDetail(orderDetail recipeDetail);
    }
}
