using AutoMapper;
using BussinessObject.MapData;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository;

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
        public ActionResult<message> updateMess(Guid blogId, blogInfo dto)
        {
            var foo = _mapper.Map<message>(dto);
            if (foo.messageId != blogId)
            {
                return BadRequest();
            }
            try
            {
                foodRepository.UpdateMessage(foo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (foodRepository.GetmessagesById(blogId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
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
