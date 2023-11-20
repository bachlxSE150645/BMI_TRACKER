using AutoMapper;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using BussinessObject.MapData;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplementController : ControllerBase
    {
        private IComplementRepository comRepository;
        private IMapper _mapper;
        
        public ComplementController(MyDbContext dbContext, IMapper mapper)
        {
            comRepository = new ComplementRepository(dbContext);
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllComps()
        {
            try
            {
                return Ok(comRepository.GetAllComplemennts());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("email")]
        public ActionResult<complement> GetFoodById(string email)
        {
            try
            {
                return Ok(comRepository.getaALLCompsByUserEmail(email));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("addNewCompByBlog")]
        public async Task<IActionResult> addNewCompByBlog(ComplementInfo dto)
        {
            var food = _mapper.Map<complement>(dto);

            var result = comRepository.addNewCompByBlog(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPost("addNewCompByService")]
        public async Task<IActionResult> addNewCompByService(ComplementInfo dto)
        {
            var food = _mapper.Map<complement>(dto);

            var result = comRepository.addNewCompByService(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPost("addNewCompByUser")]
        public async Task<IActionResult> addNewCompByUser(ComplementInfo dto)
        {
            var food = _mapper.Map<complement>(dto);

            var result = comRepository.addNewCompByBlog(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }


    }
}
