using AutoMapper;
using BussinessObject;
using BussinessObject.MapData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class foodController : ControllerBase
    {
        private IFoodRepository foodRepository;
        private readonly IMapper _mapper;
        public foodController(MyDbContext dbContext, IMapper mapper)
        {
            foodRepository = new foodRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFood()
        {
            try
            {
                return Ok(foodRepository.GetFoodList());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("FoodId")]
        public ActionResult<food> GetFoodById(Guid foodId)
        {
            try
            {
                return Ok(foodRepository.getFoodById(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddFood(foodInfo dto)
        {
            var food = _mapper.Map<food>(dto);
            food.status = "available";
            var result = await foodRepository.AddNewFood(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public  ActionResult<food> updateFood(Guid foodId, foodInfo dto)
        {
            var foo = _mapper.Map<food>(dto);
            if (foo.foodId != foodId)
            {
                return BadRequest();
            }
            try
            {
                foodRepository.UpdateFood(foo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (foodRepository.getFoodById(foodId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("food")]
        public IActionResult DeleteFood(Guid foo)
        {
            try
            {
                var fooId = foodRepository.getFoodById(foo);
                if (fooId == null)
                {
                    return NotFound();
                }
                fooId.status = "hidden";
                foodRepository.UpdateFood(fooId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
