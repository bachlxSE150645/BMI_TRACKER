using AutoMapper;
using BussinessObject.MapData;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository;
using DataAccess;
using System.Net.Mime;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class messageController : ControllerBase
    {
        private IMessageRepository foodRepository;
        private readonly IMapper _mapper;
        public messageController(MyDbContext dbContext, IMapper mapper)
        {
            foodRepository = new messageRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            try
            {
                return Ok(foodRepository.GetMessages());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("messId")]
        public ActionResult<food> GetmessById(Guid foodId)
        {
            try
            {
                return Ok(foodRepository.GetmessagesById(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddMess(messInfo dto)
        {
            var food = _mapper.Map<message>(dto);
            food.status = "available";
            var result = await foodRepository.Addmessages(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public ActionResult<message> updateMess(Guid messId, string Content, string file)
        {
            try
            {
                var us = foodRepository.GetmessagesById(messId);
                if (us == null)
                {
                    return BadRequest();
                }
                Content = us.Content;
                file = us.file;
                foodRepository.UpdateMessage(us);
                return Ok(us);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("mess")]
        public IActionResult DeleteMess(Guid foo)
        {
            try
            {
                var fooId = foodRepository.GetmessagesById(foo);
                if (fooId == null)
                {
                    return NotFound();
                }
                fooId.status = "hidden";
                foodRepository.UpdateMessage(fooId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
