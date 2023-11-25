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
        private IScheduleRepository _scheduleRepository;
        public userBodyMaxController(MyDbContext dbContext, IMapper mapper)
        {
            feedbackRepository = new userBodyMaxRepository(dbContext);
            _mapper = mapper;
            _scheduleRepository = new scheduleRepository(dbContext);
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
        public ActionResult<userBodyMax> AddUserBodyMax(userBodyMaxInfo dto)
        {
            var food = _mapper.Map<userBodyMax>(dto);
            food.status = "available";
            try
            {
                if (food == null)
                {
                    return BadRequest("Something wrong!");
                }
                else
                {
                    var result = feedbackRepository.addUserBodyMax(food);
                    foreach (var item in dto.UserBodyMaxMenus)
                    {
                        var detail = _mapper.Map<Schedule>(item);
                        if (detail != null)
                        {
                            detail.userInfoId = result.userInfoId;
                            _scheduleRepository.CreteNewSchedule(detail);
                        }
                    }
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult<userBodyMax> updateUserBodyMax(Guid userInfoId, [FromBody] userBodyMaxInfo dto)
        {
            var result = feedbackRepository.updateUserBodyMax(userInfoId, dto);
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
                    _scheduleRepository.DeleteSchedule(detail);
                }
            }
            foreach (var newDetail in dto.UserBodyMaxMenus)
            {
                var detail = _mapper.Map<Schedule>(newDetail);
                detail.userInfoId = result.userInfoId;
                _scheduleRepository.CreteNewSchedule(detail);
            }
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("service")]
        public ActionResult<userBodyMax> updateServiceInUserBodyMax(Guid userInfoId, [FromBody] userBodyMaxServiceInfo dto)
        {
            try
            {
                if (userInfoId == null)
                {
                    return NotFound();
                }
                var result = feedbackRepository.updateServiceInUserBodyMax(userInfoId, dto);
                feedbackRepository.updateUserBodyMax(result);
                return Ok(result);

            }catch (Exception ex)
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
                feedbackRepository.DeleteUserBodyMax(fee);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
