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
        public ActionResult<userBodyMax> updateUserBodyMax(Guid feedId, userBodyMaxInfo dto)
        {
            var fee = _mapper.Map<userBodyMax>(dto);
            if (fee.userInfoId != feedId)
            {
                return BadRequest();
            }
            try
            {
                feedbackRepository.updateUserBodyMax(fee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (feedbackRepository.getUserBodyMaxbyId(feedId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
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
