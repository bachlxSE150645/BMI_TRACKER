using AutoMapper;
using BussinessObject.MapData;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository;
using Microsoft.AspNetCore.Cors;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
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
        public ActionResult<blog> GetBlogById(Guid foodId)
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
            
            var result = await foodRepository.addNewBlog(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpGet("userEmail")]
        public ActionResult<blog> GetBlogByUser(string email)
        {
            try
            {
                return Ok(foodRepository.getBlogByUser(email));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("userId")]
        public ActionResult<blog> GetBlogByUserId(Guid userId)
        {
            try
            {
                return Ok(foodRepository.getBlogByuserId(userId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("time")]
        public ActionResult<blog> GetBlogByUser(DateTime dateForm, DateTime dateTo)
        {
            try
            {
                return Ok(foodRepository.GetBlogByDatime(dateForm,dateTo));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("tag")]
        public ActionResult<blog> GetBlogByTag(string tag)
        {
            try
            {
                return Ok(foodRepository.selectAllBlogHaveFoodTag(tag));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult<blog> updateblog(Guid blogId, string blogName, string blogContent, string blogPhoto, string link)
        {
            try
            {
                var us = foodRepository.getBolgById(blogId);
                if (us == null)
                {
                    return BadRequest();
                }
                us.blogName = blogName;
                us.blogContent = blogContent;
                us.blogPhoto = blogPhoto;
                us.link = link;
                foodRepository.UpdateBlog(us);
                return Ok(us);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
