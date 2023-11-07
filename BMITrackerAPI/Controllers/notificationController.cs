﻿using AutoMapper;
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
    public class notificationController : ControllerBase
    {
        private INotificationRepository notificationRepository;
        private readonly IMapper _mapper;
        public notificationController(MyDbContext dbContext, IMapper mapper)
        {
            notificationRepository = new notificationRepository(dbContext);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAllNotis()
        {
            try
            {
                return Ok(notificationRepository.getAllNotis());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("notiId")]
        public ActionResult<notification> GetNOtiById(Guid foodId)
        {
            try
            {
                return Ok(notificationRepository.GetNotiById(foodId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("email")]
        public ActionResult<notification> getNotiByEmail(string email)
        {
            try
            {
                return Ok(notificationRepository.getNotiByEmail(email));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]

        public ActionResult  AddNoti(notiInfo dto)
        {
            var food = _mapper.Map<notification>(dto);
            food.status = "available";
            var result =  notificationRepository.addNoti(food);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public ActionResult<notification> updateNoti(Guid notiId, notiInfo dto)
        {
            var foo = _mapper.Map<notification>(dto);
            if (foo.notificationId != notiId)
            {
                return BadRequest();
            }
            try
            {
                notificationRepository.UpdateNoti(foo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (notificationRepository.GetNotiById(notiId) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("noti")]
        public IActionResult DeleteNoti(Guid foo)
        {
            try
            {
                var fooId = notificationRepository.GetNotiById(foo);
                if (fooId == null)
                {
                    return NotFound();
                }
                fooId.status = "hidden";
                notificationRepository.UpdateNoti(fooId);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
