using BussinessObject;
using BussinessObject.MapData;
using DAO;
using Repository.Interfaces;

namespace Repository
{
    public class userRepository : IUserRepository

    {
        private readonly userDAO dao;
        public userRepository(MyDbContext dbContext)
        {
            dao = new userDAO(dbContext);
        }

        public Task<user> addUser(user user) => dao.addUser(user);

        public bool deleteUser(user user) => dao.deleteUser(user);


        public List<user> GetAllUsers() => dao.GetAllUsers();


        public user getUserByEmailandPassword(string email, string passWord) => dao.getUserByEmailandPassword(email, passWord);


        public user getUserById(Guid id) => dao.getUserById(id);


        public List<user> searchUsersByEmail(string email) => dao.SearchAccountByEmail(email);


        public user updateAccount(user user) => dao.updateAccount(user);

        public user updateRoleTrainer(user user) =>dao.updateRoleTrainer(user);
    }
}