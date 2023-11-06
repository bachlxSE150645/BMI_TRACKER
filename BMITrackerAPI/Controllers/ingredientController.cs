using BussinessObject.MapData;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using AutoMapper;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ingredientController : ControllerBase
    {

        private readonly IIngredientRepository ingRepo;

        public ingredientController(MyDbContext dbContext)
        {
            ingRepo = new ingredientRepository(dbContext);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllIngredient()
        {
            try
            {
                return Ok(ingRepo.getAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("ingredientId")]
        public ActionResult<ingredient> GetingredientById(Guid IngredientId)
        {
            try
            {
                return Ok(ingRepo.getIngredientById(IngredientId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddIngredient(ingredient ingredient)
        {
            var result = await ingRepo.AddIngredient(ingredient);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public ActionResult<ingredient> updateIngredinet(Guid ingredientId, ingredient ingredient)
        {
            if(ingredientId != ingredient.ingredientId)
            {
                return BadRequest();
            }
            try
            {
                ingRepo.updateIngredinet(ingredient);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ingRepo.getIngredientById(ingredientId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("ingredient")]
        public IActionResult DeleteIngredient(Guid ingId)
        {
            try
            {
                var ing = ingRepo.getIngredientById(ingId);
                if (ing == null)
                {
                    return NotFound();
                }
                ing.status = "false";
                ingRepo.updateIngredinet(ing);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
