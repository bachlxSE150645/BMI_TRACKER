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
    public class roleRepository :IRoleRepository
    {
        private readonly roleDAO dao;

        public roleRepository(MyDbContext dbContext)
        {
            dao = new roleDAO(dbContext);
        }

        public role AddRole(role roleInfo) =>dao.AddRole(roleInfo);
        public void DeleteRole(role role) =>dao.DeleteRole(role);

        public role GetRoleById(Guid id)=>dao.GetRoleById(id); 

        public List<role> GetRoles() =>dao.GetRoles();

        public void UpdateRole(role role)=>dao.UpdateRole(role);
    }
}
