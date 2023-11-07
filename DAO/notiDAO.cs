using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class notiDAO
    {
        private readonly MyDbContext _context;
        public notiDAO(MyDbContext context) { _context = context; }

        public List<notification> getAllNotis()
        {
            try
            {
                return _context.notifications.ToList();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public notification GetNotiById(Guid id)
        {
            try
            {
                return _context.notifications.SingleOrDefault(x => x.notificationId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<notification> getNotiByEmail(string email)
        {   
            try
                {
                    var userNoti = from u in _context.notifications
                                   where u.users.email.Contains(email)
                                   select u;
                    return userNoti.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
         }
        public notification addNoti(notification notification)
        {
            try
            {
                var newNoti = new notification
                {
                    notificationId = Guid.NewGuid(),
                    notificationName = notification.notificationName,
                    content = notification.content,
                    type = notification.type,
                    status = "available",
                };
                _context.notifications.Add(newNoti);
                _context.SaveChanges();
                return newNoti;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateNoti(notification category)
        {
            try
            {
                var cateCheck = _context.notifications.SingleOrDefault(x => x.notificationId == category.notificationId);
                if (cateCheck != null)
                {
                    _context.Entry(cateCheck).CurrentValues.SetValues(category);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing role
        public void DeleteNoti(notification cate)
        {
            try
            {
                var cateCheck = _context.notifications.SingleOrDefault(x => x.notificationId == cate.notificationId);
                if (cateCheck != null)
                {
                    _context.notifications.Remove(cateCheck);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
