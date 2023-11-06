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
    public class serviceController : ControllerBase
    {
        private IServiceRepository foodRepository;
        private readonly IMapper _mapper;
        public serviceController(MyDbContext dbContext, IMapper mapper)
        {
            foodRepository = new serviceReposiotry(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            try
            {
                return Ok(foodRepository.GetAllServices());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("serviceId")]
        public ActionResult<Service> GetServiceById(Guid serviceId)
        {
            try
            {
                return Ok(foodRepository.getServiceById(serviceId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddService(serviceInfo dto)
        {
            var food = _mapper.Map<Service>(dto);
            food.status = "available";
            var result = await foodRepository.addNewService(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public ActionResult<Service> updateService(Guid serviceId, serviceInfo dto)
        {
            var foo = _mapper.Map < Service>(dto);
            if (foo.serviceId != serviceId)
            {
                return BadRequest();
            }
            try
            {
                foodRepository.UpdateService(foo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (foodRepository.getServiceById(serviceId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("service")]
        public IActionResult DeleteBlog(Guid foo)
        {
            try
            {
                var fooId = foodRepository.getServiceById(foo);
                if (fooId == null)
                {
                    return NotFound();
                }
                fooId.status = "hidden";
                foodRepository.UpdateService(fooId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
