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
            us.status = "available";
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

        [HttpGet("AccountID")]
        public ActionResult<user> GetuserById(Guid userId)
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
        public ActionResult<user> searchUsersByEmail(string email)
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
        public  ActionResult<user> updateUserToTrainer(Guid userId, trainerInfo info,string certId, string certName)
        {
            var tra = _mapper.Map<user>(info);
            try
            {
                if (tra.userId !=userId)
                {
                    return NotFound();
                }
                tra.certificateId = certId;
                tra.certificateName = certName;
                tra.roles.roleName = "trainer";
                return userRepo.updateUser(tra);
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("userInfomation")]
        public ActionResult<user> UpdateUser(Guid userId, string fullName, string passWord, string Email, string phoneNumber, string sex, DateTime birthday)
        {
            var uid = userRepo.getUserById(userId);
            if (uid != null)
            {
                try
                {
                    uid.email = Email;
                    uid.fullName = fullName;
                    uid.phoneNumber = phoneNumber;
                    uid.sex = sex;
                    uid.password = passWord;
                    userRepo.updateUser(uid);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (userRepo.getUserById(userId) == null)
                    {
                        return NotFound();
                    }

                    throw;
                }
                return NoContent();
            }
            return uid;

        }
    }        
 
}

