using AutoMapper;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using BussinessObject.MapData;
using Microsoft.EntityFrameworkCore;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class paymentController : ControllerBase
    {
        private IPaymentRepository foodRepository;
        private readonly IMapper _mapper;
        public paymentController(MyDbContext dbContext, IMapper mapper)
        {
            foodRepository = new paymentRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                return Ok(foodRepository.getAllpayments());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("paymentId")]
        public ActionResult<payment> GetPaymentById(Guid foodId)
        {
            try
            {
                return Ok(foodRepository.getPaymentById(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddPayment(PaymentInfo dto)
        {
            var food = _mapper.Map<payment>(dto);
            food.status = "available";
            var result = await foodRepository.AddNewPayment(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public ActionResult<payment> updatePayment(Guid blogId, PaymentInfo dto)
        {
            var foo = _mapper.Map<payment>(dto);
            if (foo.paymentId != blogId)
            {
                return BadRequest();
            }
            try
            {
                foodRepository.UpdatePayments(foo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (foodRepository.getPaymentById(blogId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("payment")]
        public IActionResult DeleteBlog(Guid foo)
        {
            try
            {
                var fooId = foodRepository.getPaymentById(foo);
                if (fooId == null)
                {
                    return NotFound();
                }
                fooId.status = "hidden";
                foodRepository.UpdatePayments(fooId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
