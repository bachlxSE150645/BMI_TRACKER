using BussinessObject;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class scheduleRepository : IScheduleRepository
    {
        private readonly scheduleDAO dao;

        public scheduleRepository(MyDbContext dbContext)
        {
            dao = new scheduleDAO(dbContext);
        }
        public Task<Schedule> CreteNewSchedule(Schedule schedule) =>dao.CreteNewSchedule(schedule);

        public void DeleteSchedule(Schedule schedule) =>dao.DeleteSchedule(schedule);

        public List<Schedule> getAllSchedules() =>dao.getAllSchedules();

        

        public List<Schedule> getScheduleByEmail(string email) =>dao.getScheduleByEmail(email);
        public Schedule getScheduleByUserIAndmenuId(Guid userId, Guid menuId)=>dao.getScheduleByUserIAndMenuId(userId, menuId);

        public List<Schedule> getScheduleByUserId(Guid userId) =>dao.getSchedulesByUserInfo(userId);

        public Schedule UpdateSchedule(Schedule sche) =>dao.UpdateSchedule(sche);
    }
}
