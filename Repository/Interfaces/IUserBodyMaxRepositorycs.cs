using BussinessObject;
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
        userBodyMax updateUserBodyMax(userBodyMax feedback);
        bool DeleteUserBodyMax(userBodyMax feedback);
    }
}
