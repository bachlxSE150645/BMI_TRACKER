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
       
        
        [HttpPost]
        public async Task<ActionResult> CreteNewSchedule( ScheduleInfo dto)
        {
            var sche = _mapper.Map<Schedule>(dto);
            
            var result = await scheRepo.CreteNewSchedule(sche);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
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
                
                scheRepo.DeleteSchedule(schedule);
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
