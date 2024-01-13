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
        public async Task<IActionResult> getAllUserBodyMaxs()
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
        [HttpGet("UserBodyMax")]
        public ActionResult<userBodyMax> getUserBodyMaxById(Guid id)
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
        public ActionResult<userBodyMax> AddUserBodyMax(userBodyMaxInfo dto, float activeRate)
        {
            var food = _mapper.Map<userBodyMax>(dto);

            try
            {
                if (food == null)
                {
                    return BadRequest("Something wrong!");
                }
                else
                {
                    var result = feedbackRepository.addUserBodyMax(food, activeRate);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult<userBodyMax> updateUserBodyMax(Guid userInfoId, [FromBody] userBodyMaxUpdateInfo dto, float activeRate)
        {
            var result = feedbackRepository.updateUserBodyMax(userInfoId, dto, activeRate);
            var current = feedbackRepository.getUserBodyMaxbyId(userInfoId);
            if (current == null)
            {
                return BadRequest();
            }
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("userBoyMax")]
        public IActionResult DeleteUserBodyMax(Guid userInfoId)
        {
            try
            {
                var current = feedbackRepository.getUserBodyMaxbyId(userInfoId);
                if (current == null)
                {
                    return NotFound();
                }
                feedbackRepository.DeleteUserBodyMax(current);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }
    }
}
