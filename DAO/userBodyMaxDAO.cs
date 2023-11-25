using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class userBodyMaxDAO
    {
        private readonly MyDbContext _context;
        public userBodyMaxDAO(MyDbContext context) { _context = context; }
        public List<userBodyMax> getAllUserBodyMax()
        {
            try
            {
                return _context.userBodyMaxes.
                    Include(u =>u.users).
                    Include(u=>u.schedules).
                    Include(u=>u.services).
                    ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public userBodyMax getUserBodyMaxbyId(Guid id)
        {
            try
            {
                return _context.userBodyMaxes.Where(feed => feed.userInfoId == id).Include(f => f.users).Include(s=>s.schedules).Include(s=>s.services).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public userBodyMax addUserBodyMax(userBodyMax feed)
        {
            try
            {
                var newUserBodyMax = new userBodyMax
                {
                    userInfoId = Guid.NewGuid(),
                    heght = feed.heght,
                    weight = feed.weight,
                    age = feed.age,
                    minimum_calories = feed.minimum_calories,
                    maximum_calories = feed.maximum_calories,
                    photo = feed.photo,
                    serviceId = feed.serviceId,
                    userId = feed.userId,
                    status = "avaiable-userBoyMax",
                    users = _context.users.Where(u => u.userId == feed.userId).FirstOrDefault(),
                    services =_context.services.Where(u=>u.serviceId == feed.serviceId).FirstOrDefault()
                };
                _context.userBodyMaxes.Add(newUserBodyMax);
                _context.SaveChanges();
                return newUserBodyMax;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public userBodyMax updateUserBodyMax(Guid id,userBodyMax userBody)
        {
            try
            {
                var foo = _context.userBodyMaxes
                     .Include(f => f.users)
                     .Include(f => f.services)
                     .Where(x => x.userInfoId.Equals(id)).SingleOrDefault();
                foo.weight = userBody.weight;
                foo.age = userBody.age;
                foo.photo = userBody.photo;
                foo.serviceId = userBody.serviceId;
                foo.status = userBody.status;
                foo.BMIPerson = userBody.BMIPerson;
                foo.maximum_calories = userBody.maximum_calories;
                foo.minimum_calories = userBody.minimum_calories;
                this._context.userBodyMaxes.Update(foo);
                this._context.SaveChanges();
                return foo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteUserBodyMax(userBodyMax feedback)
        {
            try
            {
                var check = _context.userBodyMaxes.SingleOrDefault(f => f.userInfoId == feedback.userInfoId);
                if (check != null)
                {
                    _context.userBodyMaxes.Remove(check);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
