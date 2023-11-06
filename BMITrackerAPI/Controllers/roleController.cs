using AutoMapper;
using BussinessObject;
using BussinessObject.MapData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class roleController : ControllerBase
    {
        private readonly IRoleRepository roleRepo;
        private readonly IMapper _mapper;

        public roleController(MyDbContext dbContext, IMapper mapper)
        {
            roleRepo= new roleRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                return Ok(roleRepo.GetRoles());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult PostRole(roleInfo dto)
        {
            var rol = _mapper.Map<role>(dto);

            roleRepo.AddRole(rol);
            return Ok();
        }
        [HttpGet("roleId")]
        public ActionResult<role> GetRoleById(Guid foodId)
        {
            try
            {
                return Ok(roleRepo.GetRoleById(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult<role> updateRole(Guid roleId, roleInfo dto)
        {
            var rol = _mapper.Map<role>(dto);
            if (rol.roleId != roleId)
            {
                return BadRequest();
            }
            try
            {

                roleRepo.UpdateRole(rol);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (roleRepo.GetRoleById(roleId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("role")]
        public IActionResult DeleteFood(Guid rol)
        {
            try
            {
                var role = roleRepo.GetRoleById(rol);
                if (role == null)
                {
                    return NotFound();
                }
                role.status = "hidden";
                roleRepo.UpdateRole(role);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }

}
