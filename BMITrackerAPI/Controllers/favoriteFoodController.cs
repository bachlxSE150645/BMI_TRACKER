using AutoMapper;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using BussinessObject.MapData;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class favoriteFoodController : ControllerBase
    {
        private readonly IFavoriteFoodRepository favofoodRepo;
        private readonly IMapper _mapper;

        public favoriteFoodController(MyDbContext dbContext, IMapper mapper)
        {
            favofoodRepo = new FavoritFoodRepository(dbContext);
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFavoriteFoods()
        {
            try
            {
                return Ok(favofoodRepo.GetFavoriteFood());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult PostFavoriteFood(favoriteFoodInfo ff)
        {
            try
            {
                var foo = _mapper.Map<favoriteFood>(ff);
                favofoodRepo.AddFavoriteFood(foo);
                return Ok(foo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        [HttpGet("faavoriteFood/userId")]
        public ActionResult<favoriteFood> GetfavoriteFoodByUserId(Guid userId)
        {
            try
            {
                return Ok(favofoodRepo.GetFavoriteFoodById(userId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("faavoriteFood/foodId")]
        public ActionResult<favoriteFood> GetfavoriteFoodByFoodId(Guid foodId)
        {
            try
            {
                return Ok(favofoodRepo.GetFavoriteFoodByFoodId(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("favoriteFood")]
        public IActionResult DeleteFavoriteFood(Guid foodId,Guid userId)
        {
            try
            {
                var role = favofoodRepo.GetFavoriteFoodByBoth(foodId, userId);
                if (role == null)
                {
                    return NotFound();
                }
                favofoodRepo.DeleteFavoriteFood(foodId,userId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
