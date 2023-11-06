using BussinessObject.MapData;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderDetailController : ControllerBase
    {
        private readonly IOrderDetailRepository recipeDetailRepo;

        public orderDetailController(IOrderDetailRepository _recipeDetailRepository)
        {
           this.recipeDetailRepo = _recipeDetailRepository;
        }

        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetRecipeDetailsByOrderID(Guid orderId)
        {
            try
            {
                return Ok(recipeDetailRepo.GetRecipeDetailsByOrderId(orderId));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostRecipeDetail(orderDetail inf)
        {
            var result = await recipeDetailRepo.AddOrderDetail(inf);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
    }
}
