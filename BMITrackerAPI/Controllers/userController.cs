using AutoMapper;
using BussinessObject;
using BussinessObject.MapData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using Repository;
using Repository.Interfaces;

namespace BMITrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserRepository userRepo;
        private readonly IMapper _mapper;
        public userController(MyDbContext dbContext, IMapper mapper)
        {
            userRepo = new userRepository(dbContext);
            _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(loginData inf)
        {
            var check = userRepo.getUserByEmailandPassword(inf.Email, inf.passWord);

            if (check == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(check);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(signUpData dto)
        {
            var us = _mapper.Map<user>(dto);
            var result = await userRepo.addUser(us);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                return Ok(userRepo.GetAllUsers());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("userId")]
        public ActionResult<user> getUserById(Guid userId)
        {
            try
            {
                return Ok(userRepo.getUserById(userId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("email")]
        public async Task<IActionResult> searchUsersByEmail(string email)
        {
            try
            {
                return Ok(userRepo.searchUsersByEmail(email));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("Trainer")]
        public  ActionResult<user> updateUserToTrainer(Guid userId, string certificateId,  string certificateName)
        {
            
            try
            {
                if( userId == null)
                {
                    return NotFound();
                }
                var tra = userRepo.getUserById(userId);
                tra.certificateId = certificateId;
                tra.certificateName = certificateName;
                tra.status = "watting-trainer";
                userRepo.updateAccount(tra);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("TrainerApprove")]
        public ActionResult<user> AdminupdateUserToTrainerApprove(Guid userId)
        {

            try
            {
                if (userId == null)
                {
                    return NotFound();
                }
                var tra = userRepo.getUserById(userId);
                userRepo.updateRoleTrainer(tra);
                userRepo.updateAccount(tra);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult UpdateUser(Guid userId, string fullname, string Password, string Email,string phoneNumber, string sex )
        {

            try
            {
                var us =  userRepo.getUserById(userId);
                if(us == null)
                {
                    return BadRequest();
                }
                us.phoneNumber = phoneNumber;
                us.email = Email;
                us.password = Password;
                us.sex = sex;
                us.fullName = fullname;
                userRepo.updateAccount(us);
                return Ok();
            }
            catch(Exception ex)
            {
                throw  new Exception(ex.Message);
            }
            
        }
    }        
 
}

