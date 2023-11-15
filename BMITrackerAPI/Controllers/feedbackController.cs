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
    public class feedbackController : ControllerBase
    {
        private IFeedbackRepository feedbackRepository;
        private readonly IMapper _mapper;
        public feedbackController(MyDbContext dbContext, IMapper mapper)
        {
            feedbackRepository = new feedbackRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task <IActionResult> getAllFeedBacks()
        {
            try
            {
                return Ok(feedbackRepository.getAllFeedBack());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("feedbackId")]
        public  ActionResult<feedback> getFeedBackById(Guid id)
        {
            try
            {
                return Ok(feedbackRepository.getFeedbackById(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public  ActionResult<feedback> AddFeedback(feedbackInfo dto)
        {
            var feedback = _mapper.Map<feedback>(dto);
            feedback.status = "waiting";
            var result = feedbackRepository.addFeedback(feedback);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }
            return Ok(result);
        }
        [HttpPut]
        public ActionResult<feedback> updateFeedback(Guid feedId, string title, string desc)
        {
            try
            {
                var us = feedbackRepository.getFeedbackById(feedId);
                if (us == null)
                {
                    return BadRequest();
                }
                us.title = title;
                us.description = desc;
                feedbackRepository.updateFeedback(us);
                return Ok(us);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("feedback")]
        public IActionResult DeleteFeedback(Guid feedId)
        {
            try
            {
                var fee = feedbackRepository.getFeedbackById(feedId);
                if (fee == null)
                {
                    return NotFound();
                }
                fee.status = "hidden";
                feedbackRepository.updateFeedback(fee);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
