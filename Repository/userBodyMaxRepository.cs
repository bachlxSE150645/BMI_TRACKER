﻿using BussinessObject;
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

        public userBodyMax addUserBodyMax(userBodyMax feed, double activeRate)=>dao.addUserBodyMax(feed,activeRate);

        public bool DeleteUserBodyMax(userBodyMax userBodyMax)=>dao.DeleteUserBodyMax(userBodyMax);

        public List<userBodyMax> getAllUserBodyMax()=>dao.getAllUserBodyMax();

        public userBodyMax getUserBodyMaxbyId(Guid id)=>dao.getUserBodyMaxbyId(id);

        public userBodyMax updateServiceInUserBodyMax(Guid id, userBodyMaxServiceInfo userBody)
        {
            var r = dao.getUserBodyMaxbyId(id);
            if(userBody.serviceId != null)
            {
                r.serviceId = userBody.serviceId;
            }
            return dao.updateServiceInUserBodyMax(id, r);
        }
        public userBodyMax updateUserBodyMax(Guid id, userBodyMaxInfo user)
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
            return dao.updateUserBodyMax(id, r);
        }
        public userBodyMax updateUserBodyMax(userBodyMax user) => dao.updateUserBodyMax(user);
    }
}
