using AutoMapper;
using BussinessObject.MapData;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplementServiceController : ControllerBase
    {
        private IComplementServiceRepository comRepository;
        private IMapper _mapper;

        public ComplementServiceController(MyDbContext dbContext, IMapper mapper)
        {
            comRepository = new ComplementServiceRepository(dbContext);
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
        public ActionResult<ComplementService> getaALLCompsByUserEmail(string email)
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
        [HttpPost("addNewCompByService")]
        public async Task<IActionResult> addNewCompByService(ComplementServiceInfo dto)
        {
            var food = _mapper.Map<ComplementService>(dto);

            var result = comRepository.addNewCompByService(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }


    }
}

