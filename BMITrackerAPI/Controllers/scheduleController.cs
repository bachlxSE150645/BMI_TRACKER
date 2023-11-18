using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository;
using BussinessObject.MapData;
using AutoMapper;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class scheduleController : ControllerBase
    {
        private readonly IScheduleRepository scheRepo;
        private readonly IMapper _mapper;
        public scheduleController(MyDbContext dbContext,IMapper mapper)
        {
            scheRepo = new scheduleRepository(dbContext);
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> getSchedules()
        {
            try
            {
                return Ok(scheRepo.getAllSchedules());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("schedule")]
        public ActionResult<Schedule> getScheduleByUserIAndmenuId(Guid userId, Guid menuId)
        {
            try
            {
                return Ok(scheRepo.getScheduleByUserIAndmenuId(userId,menuId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("email")]
        public ActionResult<Schedule> getScheduleByEmail(string email)
        {
            try
            {
                return Ok(scheRepo.getScheduleByEmail(email));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("trackName")]
        public ActionResult<Schedule> getAllSchedulesByTrackName(string trackName)
        {
            try
            {
                return Ok(scheRepo.getAllSchedulesByTrackName(trackName));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<ActionResult> CreteNewSchedule( ScheduleInfo dto)
        {
            var sche = _mapper.Map<Schedule>(dto);
            try
            {
                if (sche == null)
                {
                    return BadRequest("Something wrong!");
                }
                else
                {
                    var result = await scheRepo.CreteNewSchedule(sche);
                    
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("schedule")]
        public IActionResult DeleteSchedule(Guid menuId, Guid userId)
        {
            try
            {
                var schedule = scheRepo.getScheduleByUserIAndmenuId(menuId,userId);
                if (schedule == null)
                {
                    return NotFound();
                }
                schedule.status = "hidden";
                scheRepo.UpdateSchedule(schedule);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
        [HttpGet("ScheduleOffUser")]
        public async Task<IActionResult> getSchedulesByUserId(Guid userId)
        {
            try
            {
                return Ok(scheRepo.getScheduleByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
