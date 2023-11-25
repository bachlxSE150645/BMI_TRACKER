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
                return _context.schedules.ToList();
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
        public List<Schedule> getAllSchedulesByTrackName(string trackName)
        {
            try
            {
                var TrackS = from i in _context.schedules
                             where i.trackForms.trackFormName.Contains(trackName)
                             select i;
                return TrackS.ToList();

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
                    dateScheduled = schedule.dateScheduled,
                    userInfoId = schedule.userInfoId,
                    menuId = schedule.menuId,
                    userBodyMaxs = _context.userBodyMaxes.FirstOrDefault(u => u.userInfoId == schedule.userInfoId),
                    menus = _context.menus.FirstOrDefault(u => u.MenuId == schedule.menuId),
                    status = "available-schedule",
                };
                _context.schedules.Add(newSche);
                await _context.AddRangeAsync(schedule);
                _context.SaveChangesAsync();
                return schedule;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Schedule getScheduleByUserIAndmenuId(Guid userInfoId, Guid menuId)
        {
            try
            {
                return _context.schedules.FirstOrDefault(s => s.userInfoId == userInfoId && s.menuId == menuId);
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
                var check = _context.schedules.FirstOrDefault(s => s.userInfoId == schedule.userInfoId && s.menuId == schedule.menuId);
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
                var men = _context.schedules.FirstOrDefault(m => m.menuId == sche.menuId && m.userInfoId == sche.userInfoId);
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
