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
        userBodyMax getUserBodyMaxbyId(Guid id);
        userBodyMax addUserBodyMax(userBodyMax feed);
        userBodyMax updateUserBodyMax(Guid id, userBodyMaxInfo feedback);
        bool DeleteUserBodyMax(userBodyMax feedback);
        userBodyMax updateServiceInUserBodyMax(Guid id, userBodyMaxServiceInfo userBody);
        userBodyMax updateUserBodyMax(userBodyMax user);
    }
}
