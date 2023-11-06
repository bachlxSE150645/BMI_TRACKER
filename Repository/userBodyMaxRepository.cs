using BussinessObject;
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

        public userBodyMax addUserBodyMax(userBodyMax feed)=>dao.addUserBodyMax(feed);

        public bool DeleteUserBodyMax(userBodyMax userBodyMax)=>dao.DeleteUserBodyMax(userBodyMax);

        public List<userBodyMax> getAllUserBodyMax()=>dao.getAllUserBodyMax();

        public userBodyMax getUserBodyMaxbyId(Guid id)=>dao.getUserBodyMaxbyId(id);

        public userBodyMax updateUserBodyMax(userBodyMax userBodyMax) =>dao.updateUserBodyMax(userBodyMax);
    }
}
