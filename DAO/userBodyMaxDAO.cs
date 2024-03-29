﻿using Azure;
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
                    ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<user> getUserByUserInfoId(Guid id)
        {
            try
            {
                var menus = from u in _context.userBodyMaxes
                            where u.userInfoId == id
                            join user in _context.users on u.userId equals user.userId
                            select user;
                return menus.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public userBodyMax getUserBodyMaxbyId(Guid id)
        {
            try
            {
                return _context.userBodyMaxes.Where(feed => feed.userInfoId == id).Include(f => f.users).Include(u=>u.schedules).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<userBodyMax> LoginByUserBodyMax(string email, string password)
        {
            try
            {
                var data = from u in _context.users where u.email == email && u.password == password
                           join body in _context.userBodyMaxes on u.userId equals body.userId
                           select body;
                return data.Include(s =>s.schedules).Include(u=>u.users).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public float calculateBMI(float weight, float heght)
        {
            try
            {
                return weight / (heght / 100 * heght / 100);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public float calcutateNum(float heght, float weight,int age, sexType sex)
        {
            try
            {
                if (sex == 0)
                {
                    return (float)(66 + (13.7 * weight) + 5 + (heght) + (6.8 * age));

                }
                else
                {
                    return (float)((10 * weight) + (6.25 * heght) - (5 * age) - 161);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public userBodyMax addUserBodyMax(userBodyMax feed, float activeRate)
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
                    userId = feed.userId,
                    dateInput = DateTime.Now,
                    status = "avaiable-userBoyMax",
                    users = _context.users.Where(u => u.userId == feed.userId).FirstOrDefault(),

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
        public userBodyMax updateUserBodyMax(Guid id,userBodyMax userBody, float  activeRate)
        {
            try
            {
                var foo = _context.userBodyMaxes
                     .Include(f => f.users)
                     .Where(x => x.userInfoId.Equals(id)).SingleOrDefault();
                foo.weight = userBody.weight;
                foo.age = userBody.age;
                foo.status = userBody.status;
                foo.BMR = calcutateNum(userBody.weight, userBody.heght, userBody.age, userBody.sex);
                foo.BMIPerson = calculateBMI(userBody.weight, userBody.heght);
                foo.TDEE = (calcutateNum(userBody.weight, userBody.heght, userBody.age, userBody.sex) * activeRate);
               
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
