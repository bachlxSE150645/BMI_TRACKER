using AutoMapper;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplementController : ControllerBase
    {
        private IComplementRepository comRepository;
        
        public ComplementController(MyDbContext dbContext)
        {
            comRepository = new ComplementRepository(dbContext);
            
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
    }
}
