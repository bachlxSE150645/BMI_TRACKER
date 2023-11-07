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
    public class notificationRepository :INotificationRepository
    {
        private readonly notiDAO dao;

        public notificationRepository(MyDbContext dbContext)
        {
            dao = new notiDAO(dbContext);
        }

        public notification addNoti(notification notification) =>dao.addNoti(notification);

        public void DeleteNoti(notification notification) =>dao.DeleteNoti(notification);

        public List<notification> getAllNotis() =>dao.getAllNotis();

        public List<notification> getNotiByEmail(string email) =>dao.getNotiByEmail(email);

        public notification GetNotiById(Guid id) =>dao.GetNotiById(id);

        public void UpdateNoti(notification notification)=>dao.UpdateNoti(notification);
    }
}
