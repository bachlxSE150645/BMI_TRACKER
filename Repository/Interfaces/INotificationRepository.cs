using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface INotificationRepository
    {
        public List<notification> getAllNotis();
        public notification GetNotiById(Guid id);
        public List<notification> getNotiByEmail(string email);
        public notification addNoti(notification notification);
        public void UpdateNoti(notification notification);
        public void DeleteNoti(notification notification);

    }
}
