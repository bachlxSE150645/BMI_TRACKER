using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class recipeController : ControllerBase
    {
        private IRecipeRepository reciePro;
        public recipeController(MyDbContext dbContext)
        {
            reciePro = new recipeRepository(dbContext);
        }
        [HttpGet("FoodId")]
        public ActionResult<recipe> GetFoodById(Guid foodId)
        {
            try
            {
                return Ok(reciePro.getFoodsById(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("IngredientId")]
        public ActionResult<recipe> getIngredientById(Guid ingId)
        {
            try
            {
                return Ok(reciePro.getIngredientsById(ingId));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
