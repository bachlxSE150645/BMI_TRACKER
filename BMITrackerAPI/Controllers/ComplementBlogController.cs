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
    public class ComplementBlogController : ControllerBase
    {
        private IComplementBlogRepository comRepository;
        private IMapper _mapper;
        
        public ComplementBlogController(MyDbContext dbContext, IMapper mapper)
        {
            comRepository = new complementBlogRepository(dbContext);
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
        public ActionResult<complementBlog> getaALLCompsByUserEmail(string email)
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
        public async Task<IActionResult> addNewCompByBlog(ComplementBlogInfo dto)
        {
            var food = _mapper.Map<complementBlog>(dto);

            var result = comRepository.addNewCompByBlog(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        
        
    }
}
