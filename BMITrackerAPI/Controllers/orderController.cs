
using AutoMapper;
using BussinessObject;
using BussinessObject.MapData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interfaces;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private IOrderRepository orderRepository;
        private readonly IMapper _mapper;
        public orderController(MyDbContext dbContext, IMapper mapper)
        {
            orderRepository = new orderRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAllOrders()
        {
            try
            {
                return Ok(orderRepository.GetAllOrders());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("orderId")]
        public ActionResult<order> getOrderById(Guid id)
        {
            try
            {
                return Ok(orderRepository.getOrderById(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult<order> AddOrder(OrderInfo dto)
        {
            var food = _mapper.Map<order>(dto);

            try
            {
                if (food == null)
                {
                    return BadRequest("Something wrong!");
                }
                else
                {
                    var result = orderRepository.addOrder(food);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult<order> updateOrder(Guid id, [FromBody] updateOrderInfo dto)
        {
            var result = orderRepository.updateOrder(id, dto);
            var current = orderRepository.getOrderById(id);
            if (current == null)
            {
                return BadRequest();
            }
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("order")]
        public IActionResult DeleteOrder(Guid feedId)
        {
            try
            {
                var fee = orderRepository.getOrderById(feedId);
                if (fee == null)
                {
                    return NotFound();
                }
                orderRepository.deleteOrder(fee);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
