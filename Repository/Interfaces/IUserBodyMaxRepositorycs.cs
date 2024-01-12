using BussinessObject;
using BussinessObject.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserBodyMaxRepositorycs
    {
        List<userBodyMax> getAllUserBodyMax();
        List<user> getUserByUserInfoId(Guid id);
        userBodyMax getUserBodyMaxbyId(Guid id);
        userBodyMax addUserBodyMax(userBodyMax feed, float activeRate);
        userBodyMax updateUserBodyMax(Guid id, userBodyMaxUpdateInfo feedback, float activeRate);
        bool DeleteUserBodyMax(userBodyMax feedback);
        userBodyMax updateUserBodyMax(userBodyMax user);
    }
}
