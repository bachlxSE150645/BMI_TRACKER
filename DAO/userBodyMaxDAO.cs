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
                return _context.userBodyMaxes.Include(u =>u.users).ToList();
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
                return _context.userBodyMaxes.Where(feed => feed.userInfoId == id).Include(f => f.users).FirstOrDefault();

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
                    status = "avaiable",
                    users = _context.users.Where(u => u.userId == feed.users.userId).FirstOrDefault(),
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
        public userBodyMax updateUserBodyMax(userBodyMax feedback)
        {
            try
            {
                var check = _context.userBodyMaxes.SingleOrDefault(f => f.userInfoId == feedback.userInfoId);
                if (check != null)
                {
                    _context.Entry<userBodyMax>(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                }
                return check;
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
