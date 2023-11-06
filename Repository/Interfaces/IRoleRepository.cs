using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRoleRepository
    {
        List<role> GetRoles();
        role GetRoleById(Guid id);
        role AddRole(role roleInfo);
        void UpdateRole(role role);
        void DeleteRole(role role);

    }
}
