using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class roleDAO
    {
        private readonly MyDbContext _context;

        public roleDAO(MyDbContext context)
        {
            _context = context;
        }

        //Get all Roles
        public List<role> GetRoles()
        {
            try
            {
                return _context.roles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get role by RoleID
        public role GetRoleById(Guid id)
        {
            try
            {
                return _context.roles.SingleOrDefault(x => x.roleId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Role
        public role AddRole(role roleInfo)
        {
            try
            {
                var newRole = new role
                {
                    roleId = Guid.NewGuid(),
                    roleName = roleInfo.roleName,
                };
                _context.roles.Add(newRole);
                _context.SaveChanges();
                return newRole;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing role by Role ID
        public void UpdateRole(role role)
        {
            try
            {
                var roleCheck = _context.roles.SingleOrDefault(x => x.roleId == role.roleId);
                if (roleCheck != null)
                {
                    _context.Entry(roleCheck).CurrentValues.SetValues(role);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing role
        public void DeleteRole(role role)
        {
            try
            {
                var roleCheck = _context.roles.SingleOrDefault(x => x.roleId == role.roleId);
                if (roleCheck != null)
                {
                    _context.roles.Remove(roleCheck);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
