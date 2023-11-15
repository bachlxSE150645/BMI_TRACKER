using BussinessObject;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class complementDAO
    {
        private readonly MyDbContext _context;
        public complementDAO(MyDbContext context) { _context = context; }

          public  List<complement> GetAllComplemennts() 
        {
            try
            {
                return _context.Complements.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<complement> getaALLCompsByUserEmail(string email)
        {
            try
            {
                var comp = from c in _context.Complements
                           where c.users.email.Contains(email)
                           select c;
                return comp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
