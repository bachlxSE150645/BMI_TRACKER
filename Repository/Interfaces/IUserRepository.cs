using BussinessObject;
using BussinessObject.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        List<user> GetAllUsers();
        user getUserById(Guid id);
        user getUserByEmailandPassword(string email, string passWord);
        Task<user> addUser(user user);
        user updateUser(user user);
        bool deleteUser(user user);
        List<user> searchUsersByEmail(string email);
    }
}
