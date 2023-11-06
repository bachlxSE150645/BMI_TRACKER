using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interfaces;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mealController : ControllerBase
    {
        private readonly IMealRepository mealRepository;
        public mealController(MyDbContext dbContext)
        {
            mealRepository = new MealRepository(dbContext);
        }

        [HttpGet("menuId")]
        public ActionResult<Meal> getMenuById(Guid menuId)
        {
            try
            {
                return Ok(mealRepository.getMenusbyId(menuId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("foodId")]
        public ActionResult<Meal> getfoodsById(Guid foodId)
        {
            try
            {
                return Ok(mealRepository.getFoodsById(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
