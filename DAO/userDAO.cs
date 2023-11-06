using BussinessObject;
using BussinessObject.MapData;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace DAO
{
    public class userDAO
    {
        private readonly MyDbContext _context;
        public userDAO(MyDbContext context)
        {
            _context = context;
        }
        public List<user> GetAllUsers()
        {
            try
            {
                return _context.users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public user getUserById(Guid id)
        {
            try
            {
                return _context.users.FirstOrDefault(u => u.userId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public user getUserByEmailandPassword(string email, string passWord)
        {
            try
            {
                return _context.users.FirstOrDefault(u => u.email.Equals(email) && u.password.Equals(passWord));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<user> SearchAccountByEmail(string email)
        {
            try
            {
                var userEmail = from u in _context.users
                                where u.email.Contains(email)
                                select u;
                return userEmail.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<user> addUser(user signUpData)
        {
            try
            {
                var newAccount = new user
                {
                    email = signUpData.email,
                    password = signUpData.password,
                    phoneNumber = signUpData.phoneNumber,
                    fullName = signUpData.fullName,
                    certificateId = "null",
                    certificateName= "null",
                    userId = Guid.NewGuid(),
                    roles = _context.roles.FirstOrDefault(r => r.roleName == "user")

                };
                _context.users.Add(newAccount);
                await _context.SaveChangesAsync();
                return newAccount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public user updateAccount(user user)
        {
            try
            {
                var us = _context.users.FirstOrDefault(u => u.userId == user.userId);
                if (us != null)
                {
                    _context.Entry<user>(us).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return us;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool deleteUser(user user)
        {
            try
            {
                var us = _context.users.FirstOrDefault(u => u.userId == user.userId);
                if (us != null)
                {
                    _context.users.Remove(us);
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