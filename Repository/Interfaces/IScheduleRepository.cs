using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IScheduleRepository
    {
        List<Schedule> getAllSchedules();
        List<Schedule>getAllSchedulesByTrackName(string trackName);
        List<Schedule> getScheduleByEmail(string email);
        List<Schedule> getScheduleByUserId(Guid userId);
        Task<Schedule> CreteNewSchedule(Schedule schedule);
        Schedule getScheduleByUserIAndmenuId(Guid userId, Guid menuId);
        void DeleteSchedule(Schedule schedule);
        Schedule UpdateSchedule(Schedule sche);
    }
}
