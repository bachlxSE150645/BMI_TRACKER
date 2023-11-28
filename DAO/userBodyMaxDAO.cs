using Azure;
using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
     
        public userBodyMax addUserBodyMax(userBodyMax feed, double activeRate)
        {
            try
            {
                var newUserBodyMax = new userBodyMax
                {
                    userInfoId = Guid.NewGuid(),
                    heght = feed.heght,
                    weight = feed.weight,
                    age = feed.age,
                    sex =feed.sex,
                    BMR = calcutateNum(feed.weight,feed.heght, feed.age,feed.sex),
                    BMIPerson = calculateBMI(feed.weight,feed.heght),
                    TDEE = (calcutateNum(feed.weight, feed.heght, feed.age, feed.sex) * activeRate),
                    serviceId = feed.serviceId,
                    userId = feed.userId,
                    status = "avaiable-userBoyMax",
                    users = _context.users.Where(u => u.userId == feed.userId).FirstOrDefault(),
                    services =_context.services.Where(u=>u.serviceId == feed.serviceId).FirstOrDefault()
                };
                double calculateBMI(int weight, int heght)
                {
                    try
                    {
                         return feed.BMIPerson = weight/(heght * heght);
                       
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                 double calcutateNum(int heght, int weight, int age , sexType sex)
                {
                    try
                    {
                        if (sex == 0)
                        {
                          return  feed.BMR = (double)(66 + (13.7 * weight) + 5 + (heght) + (6.8 * age));

                        }
                        else
                        {
                           return feed.BMR = (double)((10 * weight) + (6.25 * heght) - (5 * age) - 161);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

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
                     .Where(x => x.userInfoId.Equals(id)).SingleOrDefault();
                foo.weight = userBody.weight;
                foo.age = userBody.age;
                foo.status = userBody.status;
                foo.BMIPerson = userBody.BMIPerson;
                foo.BMR = userBody.BMR;
                foo.TDEE = userBody.TDEE;
                foo.serviceId = Guid.NewGuid();
                this._context.userBodyMaxes.Update(foo);
                this._context.SaveChanges();
                return foo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public userBodyMax updateServiceInUserBodyMax (Guid id,userBodyMax userBody)
        {
            try
            {
                var foo =_context.userBodyMaxes.Include(f => f.services).SingleOrDefault(i=>i.userInfoId.Equals(id));
                foo.serviceId = userBody.serviceId;
                foo.services = _context.services.SingleOrDefault(u => u.serviceId == userBody.serviceId);

                this._context.userBodyMaxes.Update(foo);
                this._context.SaveChanges();
                return foo;
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
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
        public userBodyMax updateUserBodyMax(userBodyMax user)
        {
            try
            {
                var check = _context.userBodyMaxes.SingleOrDefault(f => f.userInfoId == user.userInfoId);
                if (check != null)
                {
                    _context.userBodyMaxes.Update(check);
                    _context.SaveChanges();
                }
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
