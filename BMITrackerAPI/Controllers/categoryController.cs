using AutoMapper;
using BussinessObject.MapData;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoryController : ControllerBase
    {
        private readonly ICategoryRepository cateRepo;
        private readonly IMapper _mapper;
        public categoryController(MyDbContext dbContext, IMapper mapper)
        {
            cateRepo = new categoryRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategorys()
        {
            try
            {
                return Ok(cateRepo.GetCat());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult PostCategory(cateInfo dto)
        {

            var food = _mapper.Map<Category>(dto);

            var result = cateRepo.AddCategory(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpGet("cateId")]
        public ActionResult<Category> GetCategoryByiD(Guid categoryId)
        {
            try
            {
                return Ok(cateRepo.GetCategoryById(categoryId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult<Category> updateCategory(Guid cateId, Category category)
        {
            var cate = cateRepo.GetCategoryById(cateId);
            if (cate.CategoryId!= cateId)
            {
                return BadRequest();
            }
            try
            {

                cateRepo.UpdateCategory(cate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (cateRepo.GetCategoryById(cateId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("category")]
        public IActionResult DeleteCategory(Guid cat)
        {
            try
            {
                var category = cateRepo.GetCategoryById(cat);
                if (category == null)
                {
                    return NotFound();
                }
                category.status = "hidden";
                cateRepo.UpdateCategory(category);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
