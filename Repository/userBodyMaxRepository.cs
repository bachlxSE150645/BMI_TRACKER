using BussinessObject;
using BussinessObject.MapData;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class userBodyMaxRepository :IUserBodyMaxRepositorycs
    {
        private readonly userBodyMaxDAO dao;

        public userBodyMaxRepository(MyDbContext dbContext)
        {
            dao = new userBodyMaxDAO(dbContext);
        }

        public userBodyMax addUserBodyMax(userBodyMax feed, float activeRate)=>dao.addUserBodyMax(feed,activeRate);

        public bool DeleteUserBodyMax(userBodyMax userBodyMax)=>dao.DeleteUserBodyMax(userBodyMax);

        public List<userBodyMax> getAllUserBodyMax()=>dao.getAllUserBodyMax();

        public userBodyMax getUserBodyMaxbyId(Guid id)=>dao.getUserBodyMaxbyId(id);

        public List<user> getUserByUserInfoId(Guid id)=>dao.getUserByUserInfoId(id);

        public userBodyMax updateUserBodyMax(Guid id, userBodyMaxUpdateInfo user, float activeRate)
        {
            var r = dao.getUserBodyMaxbyId(id);
            if (user.heght !=null)
            {
                r.heght = user.heght;
            }
            if (user.weight !=null)
            {
                r.weight = user.weight;
            }
            if(user.age != null)
            {
                r.age = user.age;
            }
            return dao.updateUserBodyMax(id, r,activeRate);
        }
        public userBodyMax updateUserBodyMax(userBodyMax user) => dao.updateUserBodyMax(user);
    }
}
