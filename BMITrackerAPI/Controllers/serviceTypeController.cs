using AutoMapper;
using BussinessObject.MapData;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository;
using DataAccess;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class serviceTypeController : ControllerBase
    {
        private IServiceTypeRepository foodRepository;
        private readonly IMapper _mapper;
        public serviceTypeController(MyDbContext dbContext, IMapper mapper)
        {
            foodRepository = new serviceTypeRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAllServiceTypes()
        {
            try
            {
                return Ok(foodRepository.GetAllServices());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("serviceTypeId")]
        public ActionResult<Service> GetServiceTypeById(Guid serviceId)
        {
            try
            {
                return Ok(foodRepository.getServiceTypeById(serviceId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddService(serviveTypeInfo dto)
        {
            var food = _mapper.Map<ServiceType>(dto);
            food.status = "available";
            var result = await foodRepository.addNewServiceType(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public ActionResult<ServiceType> updateService(Guid serviceId, serviveTypeInfo dto)
        {
            var foo = _mapper.Map <ServiceType>(dto);
            if (foo.ServiceTypeId != serviceId)
            {
                return BadRequest();
            }
            try
            {
                foodRepository.UpdateServiceType(foo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (foodRepository.getServiceTypeById(serviceId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("service")]
        public IActionResult DeleteService(Guid foo)
        {
            try
            {
                var fooId = foodRepository.getServiceTypeById(foo);
                if (fooId == null)
                {
                    return NotFound();
                }
                fooId.status = "hidden";
                foodRepository.UpdateServiceType(fooId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
