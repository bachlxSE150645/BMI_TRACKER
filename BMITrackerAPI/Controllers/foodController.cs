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
            var result = await foodRepository.AddNewFood(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public  ActionResult<food> updateFood(Guid foodId, string foodName, string foodTag, string foodNutrition,string foodNotes, string foodPhoto, int foodtimeProcess,  int foodCalorios , string foodProcessingVideo)
        {
            try
            {
                var us = foodRepository.getFoodById(foodId);
                if (us == null)
                {
                    return BadRequest();
                }
                foodName = us.foodName;
                foodCalorios = us.foodCalorios;
                foodNotes = us.foodNotes;
                foodNutrition = us.foodNutrition;
                foodPhoto = us.foodPhoto;
                foodTag = us.foodTag;

                foodRepository.UpdateFood(us);
                return Ok(us);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
