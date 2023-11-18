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
        private IRecipeRepository recRepository;
        public foodController(MyDbContext dbContext, IMapper mapper)
        {
            foodRepository = new foodRepository(dbContext);
            _mapper = mapper;
            recRepository = new recipeRepository(dbContext);
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
        [HttpGet("FoodTag")]
        public async Task<IActionResult> GetfoodByTag(string tag)
        {
            try
            {
                return Ok(foodRepository.GetFoodByTag(tag));
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
            try
            {
                if (food == null)
                {
                    return BadRequest("Something wrong!");
                }
                else
                {
                    var result = await foodRepository.AddNewFood(food);
                    foreach (var item in dto.ingredients)
                    {
                        var detail = _mapper.Map<recipe>(item);
                        if (detail != null)
                        {
                            detail.foodId = result.foodId;
                            recRepository.createnewRecipe(detail);
                        }
                    }
                    return Ok(result);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }                     
        }
        [HttpPut]
        public  ActionResult<food> updateFood(Guid foodId, [FromBody] foodInfo dto)
        {
            var result =  foodRepository.UpdateFood(foodId,dto);
            var current = foodRepository.getFoodById(foodId);
            if (current == null)
            {
                return BadRequest();
            }
            foreach (var detail in current.recipes)
            {
                Console.WriteLine(detail);
                if (detail != null)
                {
                    recRepository.DeleteRecipeDetail(detail);
                }
            }
            foreach(var newDetail in dto.ingredients)
            {
                var detail = _mapper.Map<recipe>(newDetail);
                detail.foodId = result.foodId;
                recRepository.createnewRecipe(detail);
            }
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
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
                foodRepository.DeleteFood(fooId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
