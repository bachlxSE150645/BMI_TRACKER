using AutoMapper;
using BussinessObject;
using BussinessObject.MapData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private readonly IOrderRepository orderRepo;
        private readonly IOrderDetailRepository orderDetailRepo;
        private readonly IMapper _mapper;

        public orderController(IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            orderRepo = orderRepository;
            _mapper = mapper;
            orderDetailRepo = orderDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(string? orderName = "")
        {
            if (string.IsNullOrWhiteSpace(orderName))
            {
                return Ok(await orderRepo.GetOrders());
            }
            else
            {
                List<Order> recipes = orderRepo.GetOrdersByName(orderName);
                return Ok(await Task.FromResult(recipes));
            }

        }
        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetOrderByID(Guid orderId)
        {
            try
            {
                return Ok(orderRepo.GetOrderById(orderId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult PostOrder(orderInfo dto)
        {
            var recipe = _mapper.Map<Order>(dto);
            recipe.status = "available";
            try
            {
                if (recipe == null)
                {
                    return BadRequest("Something wrong!");
                }
                else
                {
                    var result = orderRepo.AddOrder(recipe);
                    foreach (var item in dto.orderDetailsDTO)
                    {
                        var detail = _mapper.Map<orderDetail>(item);
                        if (detail != null)
                        {
                            detail.orderId = result.orderId;
                            orderDetailRepo.AddOrderDetail(detail);
                        }
                    }
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPut("orderId")]
        public ActionResult PutOrder(orderInfo dto, Guid id)
        {
            var order = _mapper.Map<Order>(dto);
            var result =  orderRepo.UpdateOrder(order,id);
            var current = orderRepo.GetOrderById(id);
            if (current == null)
            {
                return BadRequest();
            }

            foreach (var detail in current.orderDetails)
            {
                Console.WriteLine(detail);
                if (detail != null)
                {
                    orderDetailRepo.DeleteOrderDetail(detail);
                }
            }
            foreach (var newDetail in dto.orderDetailsDTO)
            {
                var detail = _mapper.Map<orderDetail>(newDetail);
                detail.orderId = result.orderId;
                 orderDetailRepo.AddOrderDetail(detail);
            }
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);


        }
    }
}
