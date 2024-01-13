using Azure.Identity;
using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class scheduleDAO
    {
        private readonly MyDbContext _context;
        public scheduleDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Schedule> getAllSchedules()
        {
            try
            {
                return _context.schedules.
                    Include(u=>u.userBodyMaxs)
                    .Include(u=>u.menus)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Schedule> getSchedulesByUserInfo(Guid userInfoId)
        {
            try
            {
                return _context.schedules.Where(s => s.userInfoId == userInfoId)
                    .Include(u => u.userBodyMaxs)
                    .Include(m => m.menus).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Schedule> getScheduleByEmail (string email)
        {
            try
            {
                var ScheEmail = from s in _context.schedules
                                where s.userBodyMaxs.users.email.Contains(email)
                                select s;
                return ScheEmail.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
        public Schedule getMenuIdByuserBodyMax(Guid userInfoId)
        {
            try
            {
                return _context.schedules.Where(u => u.userInfoId == userInfoId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Schedule> CreteNewSchedule(Schedule schedule)
        {
            try
            {
                var newSche = new Schedule
                {
                    userInfoId = schedule.userInfoId,
                    MenuId = schedule.MenuId,
                    userBodyMaxs = _context.userBodyMaxes.FirstOrDefault(u => u.userInfoId == schedule.userInfoId),
                    menus = _context.menus.FirstOrDefault(u => u.MenuId == schedule.MenuId),
                };
                await _context.schedules.AddAsync(newSche);
                _context.SaveChangesAsync();
                return newSche;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Schedule getScheduleByUserIAndMenuId(Guid userInfoId, Guid MenuId)
        {
            try
            {
                return _context.schedules.Include(u => u.userBodyMaxs)
                    .Include(m => m.menus).FirstOrDefault(s => s.userInfoId == userInfoId && s.MenuId == MenuId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteSchedule(Schedule schedule)
        {
            try
            {
                var check = _context.schedules.FirstOrDefault(s => s.userInfoId == schedule.userInfoId && s.MenuId == schedule.MenuId);
                if (check != null)
                {
                    _context.schedules.Remove(check);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Schedule UpdateSchedule(Schedule sche)
        {
            try
            {
                var men = _context.schedules.FirstOrDefault(m => m.MenuId == sche.MenuId && m.userInfoId == sche.userInfoId);
                if (men != null)
                {
                    _context.Entry<Schedule>(sche).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return men;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
