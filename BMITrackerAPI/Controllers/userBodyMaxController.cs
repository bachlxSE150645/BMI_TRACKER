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
using DataAccess;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userBodyMaxController : ControllerBase
    {
        private IUserBodyMaxRepositorycs feedbackRepository;
        private readonly IMapper _mapper;
        private IScheduleRepository _scheRepository;
        public userBodyMaxController(MyDbContext dbContext, IMapper mapper)
        {
            feedbackRepository = new userBodyMaxRepository(dbContext);
            _mapper = mapper;
            _scheRepository = new scheduleRepository(dbContext);    
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
        [HttpGet("user")]
        public async Task<IActionResult> GetUserByUserBodyMax(Guid userInfoId)
        {
            try
            {
                return Ok(feedbackRepository.getUserByUserInfoId(userInfoId));
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
            try
            {
                var result = feedbackRepository.updateUserBodyMax(userInfoId, dto, activeRate);
                var current = feedbackRepository.getUserBodyMaxbyId(userInfoId);

                if (current == null)
                {
                    return BadRequest();
                }
                foreach (var detail in current.schedules)
                {
                    Console.WriteLine(detail);
                    if (detail != null)
                    {
                        _scheRepository.DeleteSchedule(detail);
                    }
                }
                foreach (var newDetail in dto.userBodyMaxMenus)
                {
                    var detail = _mapper.Map<Schedule>(newDetail);
                    detail.userInfoId = result.userInfoId;
                    _scheRepository.CreteNewSchedule(detail);
                }
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        [HttpDelete("userBoyMax")]
        public IActionResult DeleteUserBodyMax(Guid userInfoId)
        {
            try
            {
                var current = feedbackRepository.getUserBodyMaxbyId(userInfoId);
                foreach (var detail in current.schedules)
                {
                    Console.WriteLine(detail);
                    if (detail != null)
                    {
                        _scheRepository.DeleteSchedule(detail);
                    }
                }
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
