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
        public List<user> getAllTrainer();
        List<Guid> GetUserBodyMaxByUserId(Guid userId);
        user getUserById(Guid id);
        user getUserByEmailandPassword(user user);
        Task<user> addUser(user user);
        user updateAccount(user user);
        bool deleteUser(user user);
        List<user> searchUsersByEmail(string email);
        user updateRoleTrainer(user user);
    }
}
