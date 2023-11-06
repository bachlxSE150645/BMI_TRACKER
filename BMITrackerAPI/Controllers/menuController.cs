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
    public class menuController : ControllerBase
    {
        private IMenuRepository menuRepo;
        private readonly IMapper _mapper;
        public menuController(MyDbContext dbContext, IMapper mapper)
        {
            menuRepo = new menuRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            try
            {
                return Ok(menuRepo.getAllMenu());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("menuId")]
        public ActionResult<Menu> getMenuById(Guid foodId)
        {
            try
            {
                return Ok(menuRepo.getMenuById(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddMenu(MenuInfo dto)
        {
            var men = _mapper.Map<Menu>(dto);
            men.status = "available";
            var result = await menuRepo.AddNewFood(men);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public ActionResult<Menu> updateMenu(Guid menuId, MenuInfo dto)
        {
            var foo = _mapper.Map<Menu>(dto);
            if (foo.MenuId != menuId)
            {
                return BadRequest();
            }
            try
            {
                menuRepo.UpdateFood(foo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (menuRepo.getMenuById(menuId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("menu")]
        public IActionResult DeleteMenu(Guid foo)
        {
            try
            {
                var fooId = menuRepo.getMenuById(foo);
                if (fooId == null)
                {
                    return NotFound();
                }
                fooId.status = "hidden";
                menuRepo.UpdateFood(fooId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
