using AutoMapper;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using BussinessObject.MapData;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class menuController : ControllerBase
    {
        private IMenuRepository menuRepo;
        private readonly IMapper _mapper;
        private IMealRepository _mealRepository;
        public menuController(MyDbContext dbContext, IMapper mapper)
        {
            menuRepo = new menuRepository(dbContext);
            _mapper = mapper;
            _mealRepository = new MealRepository(dbContext);
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
        public ActionResult<Menu> getMenuById(Guid menuId)
        {
            try
            {
                return Ok(menuRepo.getMenuById(menuId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("foodByMenuId")]
        public async Task<IActionResult> GetFoodByMenuName(string menuName)
        {
            try
            {
                return Ok(menuRepo.getFoodByMenuName(menuName));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public async Task<IActionResult> AddMenu(MenuInfo dto)
        {
            var food = _mapper.Map<Menu>(dto);
            food.status = "available";
            try
            {
                if (food == null)
                {
                    return BadRequest("Something wrong!");
                }
                else
                {
                    var result = await menuRepo.AddNewMenu(food);
                    foreach (var item in dto.foods)
                    {
                        var detail = _mapper.Map<Meal>(item);
                        if (detail != null)
                        {
                            detail.menuId = result.MenuId;
                            _mealRepository.createnewMeal(detail);
                        }
                    }
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult<Menu> updateMenu(Guid menuId, [FromBody] MenuInfo dto)
        {
            try
            {

                var result = menuRepo.UpdateMenu(menuId, dto);
                var current = menuRepo.getMenuById(menuId);
                if (current == null)
                {
                    return BadRequest();
                }
                foreach (var detail in current.meals)
                {
                    Console.WriteLine(detail);
                    if (detail != null)
                    {
                        _mealRepository.DeleteMeal(detail);
                    }
                }
                foreach (var newDetail in dto.foods)
                {
                    var detail = _mapper.Map<Meal>(newDetail);
                    detail.menuId = result.MenuId;
                    _mealRepository.createnewMeal(detail);
                }
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("menu")]
        public IActionResult DeleteMenu(Guid menuId)
        {
            try
            {
                var current = menuRepo.getMenuById(menuId);
                if (current == null)
                {
                    return NotFound();
                }
                foreach (var detail in current.schedules)
                {
                    if (detail != null)
                    {
                        throw new Exception(" cant delete this menu its belong to some userBodyMaxs");
                    }
                }
                foreach (var detail in current.meals)
                {
                    Console.WriteLine(detail);
                    if (detail != null)
                    {
                        _mealRepository.DeleteMeal(detail);
                    }
                }
                menuRepo.deleteMenu(current);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
