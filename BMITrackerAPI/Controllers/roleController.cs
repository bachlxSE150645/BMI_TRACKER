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
        public ActionResult updateRole(Guid roleId, string roleName)
        {
            try
            {
                var us = roleRepo.GetRoleById(roleId);
                if (us == null)
                {
                    return BadRequest();
                }
                us.roleName = roleName;
                roleRepo.UpdateRole(us);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpDelete("role")]
        public IActionResult DeleteRole(Guid rol)
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
