using AutoMapper;
using BussinessObject.MapData;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class blogController : ControllerBase
    {
        private IBlogRepository foodRepository;
        private readonly IMapper _mapper;
        public blogController(MyDbContext dbContext, IMapper mapper)
        {
            foodRepository = new BlogRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            try
            {
                return Ok(foodRepository.GetAllBlogs());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("blogId")]
        public ActionResult<blog> GetFoodById(Guid foodId)
        {
            try
            {
                return Ok(foodRepository.getBolgById(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddBlog(blogInfo dto)
        {
            var food = _mapper.Map<blog>(dto);
            food.status = "available";
            var result = await foodRepository.addNewBlog(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public ActionResult<blog> updateblog(Guid blogId, blogInfo dto)
        {
            var foo = _mapper.Map < blog>(dto);
            if (foo.bolgId != blogId)
            {
                return BadRequest();
            }
            try
            {
                foodRepository.UpdateBlog(foo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (foodRepository.getBolgById(blogId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("blog")]
        public IActionResult DeleteBlog(Guid foo)
        {
            try
            {
                var fooId = foodRepository.getBolgById(foo);
                if (fooId == null)
                {
                    return NotFound();
                }
                fooId.status = "hidden";
                foodRepository.UpdateBlog(fooId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
