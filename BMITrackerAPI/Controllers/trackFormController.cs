using AutoMapper;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using BussinessObject.MapData;
using Microsoft.EntityFrameworkCore;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class trackFormController : ControllerBase
    {
        private ITrackFormRepository feedbackRepository;
        private readonly IMapper _mapper;
        public trackFormController(MyDbContext dbContext, IMapper mapper)
        {
            feedbackRepository = new trackFormRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAllTrackforms()
        {
            try
            {
                return Ok(feedbackRepository.GetTracksFromList());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public ActionResult<feedback> getTrackformById(Guid id)
        {
            try
            {
                return Ok(feedbackRepository.GetTrackFormById(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public ActionResult<trackForm> AddTrackform(trackformInfo dto)
        {
            var feedback = _mapper.Map<trackForm>(dto);
            feedback.status = "availabel";
            var result = feedbackRepository.AddTrackForm(feedback);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }
            return Ok(result);
        }
        [HttpPut]
        public ActionResult<trackForm> updateTrackform(Guid trackId, string trackFormName, string trackeFormDescription, bool isTracked)
        {

            try
            {
                var us = feedbackRepository.GetTrackFormById(trackId);
                if (us == null)
                {
                    return BadRequest();
                }
                trackFormName = us.trackFormName;
                trackeFormDescription = us.trackeFormDescription;
                isTracked = true;
                feedbackRepository.updateTrackform(us);
                return Ok(us);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("trackform")]
        public IActionResult DeleteTrackeForm(Guid trackId)
        {
            try
            {
                var fee = feedbackRepository.GetTrackFormById(trackId);
                if (fee == null)
                {
                    return NotFound();
                }
                fee.status = "hidden";
                feedbackRepository.updateTrackform(fee);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
