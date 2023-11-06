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
        public List<Schedule> getSchedulesByUserId(Guid userId)
        {
            try
            {
                return _context.schedules.Where(s => s.userId == userId)
                    .Include(u => u.userBodyMaxs)
                    .Include(m => m.menus).ToList();
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
                    status = "available",
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
        public Schedule getScheduleByUserIAndmenuId(Guid userId, Guid menuId)
        {
            try
            {
                return _context.schedules.FirstOrDefault(s => s.userId == userId && s.menuId == menuId);
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
                var check = _context.schedules.FirstOrDefault(s => s.userId == schedule.userId && s.menuId == schedule.menuId);
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
                var men = _context.schedules.FirstOrDefault(m => m.menuId == sche.menuId && m.userId== sche.userId);
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
