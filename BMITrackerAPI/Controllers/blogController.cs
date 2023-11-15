﻿using AutoMapper;
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
            
            var result = await foodRepository.addNewBlog(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
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
