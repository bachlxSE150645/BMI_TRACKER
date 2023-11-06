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
    public class feedbackCategoryController : ControllerBase
    {
        private readonly IFeebackCategoryRepository cateRepo;
        public feedbackCategoryController(MyDbContext dbContext)
        {
            cateRepo = new feebackCategoryRepository(dbContext);

        }
        [HttpGet]
        public async Task<IActionResult> GetFeedbackCategorys()
        {
            try
            {
                return Ok(cateRepo.GetFeedbackCategorys());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult PostFeedbackCategory(feebackCategory category)
        {

            cateRepo.AddFeebackCategory(category);
            return Ok();
        }
        [HttpGet("feebackCategoryId")]
        public ActionResult<feebackCategory> GetfeebackCategoryByiD(Guid categoryId)
        {
            try
            {
                return Ok(cateRepo.GetFeedbackCategoryById(categoryId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult<feebackCategory> updatefeebackCategory(Guid cateId, feebackCategory category)
        {
            var cate = cateRepo.GetFeedbackCategoryById(cateId);
            if (cate.feedbackCategoryId!= cateId)
            {
                return BadRequest();
            }
            try
            {

                cateRepo.UpdatefeebackCategory(cate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (cateRepo.GetFeedbackCategoryById(cateId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("feebackCategory")]
        public IActionResult DeleteCategory(Guid cat)
        {
            try
            {
                var category = cateRepo.GetFeedbackCategoryById(cat);
                if (category == null)
                {
                    return NotFound();
                }
                category.status = "hidden";
                cateRepo.UpdatefeebackCategory(category);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
