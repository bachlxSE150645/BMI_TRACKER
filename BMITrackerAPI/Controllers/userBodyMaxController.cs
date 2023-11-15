using AutoMapper;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using System.ComponentModel;
using System.Collections.Specialized;
using BussinessObject.MapData;
using Microsoft.EntityFrameworkCore;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userBodyMaxController : ControllerBase
    {
        private IUserBodyMaxRepositorycs feedbackRepository;
        private readonly IMapper _mapper;
        public userBodyMaxController(MyDbContext dbContext, IMapper mapper)
        {
            feedbackRepository = new userBodyMaxRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task <IActionResult> getAllUserBodyMaxs()
        {
            try
            {
                return Ok(feedbackRepository.getAllUserBodyMax());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("feedbackId")]
        public  ActionResult<userBodyMax> getFeedBackById(Guid id)
        {
            try
            {
                return Ok(feedbackRepository.getUserBodyMaxbyId(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public  ActionResult<userBodyMax> AddUserBodyMax(userBodyMaxInfo dto)
        {
            var feedback = _mapper.Map<userBodyMax>(dto);
            feedback.status = "available";
            var result = feedbackRepository.addUserBodyMax(feedback);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }
            return Ok(result);
        }
        [HttpPut]
        public ActionResult<userBodyMax> updateUserBodyMax(Guid userInfoId, int heght , int weight, int minimum_calories,int maximum_calories, string photo,int age)
        {
            try
            {
                var us = feedbackRepository.getUserBodyMaxbyId(userInfoId);
                if (us == null)
                {
                    return BadRequest();
                }
                heght = us.heght;
                weight = us.weight;
                minimum_calories  = us.minimum_calories;
                maximum_calories = us.maximum_calories;
                photo =us.photo;
                age = us.age;
                feedbackRepository.updateUserBodyMax(us);
                return Ok(us);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("userBoyMax")]
        public IActionResult DeleteUserBodyMax(Guid feedId)
        {
            try
            {
                var fee = feedbackRepository.getUserBodyMaxbyId(feedId);
                if (fee == null)
                {
                    return NotFound();
                }
                fee.status = "hidden";
                feedbackRepository.updateUserBodyMax(fee);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
