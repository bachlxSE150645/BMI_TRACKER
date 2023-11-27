using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class complementServiceDAO
    {
        private readonly MyDbContext _context;
        public complementServiceDAO(MyDbContext context) { _context = context; }

          public  List<ComplementService> GetAllComplemennts() 
        {
            try
            {
                return _context.ComplementServices
                    .Include(u=>u.users)
                    .Include(b=>b.services)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ComplementService> getaALLCompsByUserEmail(string email)
        {
            try
            {
                var comp = from c in _context.ComplementServices
                           where c.users.email.Contains(email)
                           select c;
                return comp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ComplementService addNewCompByService (ComplementService comp)
        {
            try
            {
                var NewComp = new ComplementService
                {
                    ComplementServiceId = Guid.NewGuid(),
                    quantity = comp.quantity,
                    serviceId = comp.serviceId,
                    
                    userId = comp.userId,
                    users = _context.users.SingleOrDefault(u => u.userId == comp.userId),
                    services = _context.services.SingleOrDefault(u => u.serviceId == comp.serviceId),
                    status = "available-com-service"
                };
                _context.ComplementServices.Add(NewComp);
                _context.SaveChanges();
                return NewComp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
       
            public ComplementService UpdateComplement(ComplementService blog)
        {
            try
            {
                var blo = _context.ComplementServices.FirstOrDefault(f => f.ComplementServiceId == blog.ComplementServiceId);
                if (blo != null)
                {
                    _context.Entry<ComplementService>(blo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return blo;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool deleteComplement(ComplementService food)
        {
            try
            {
                var foo = _context.ComplementServices.FirstOrDefault(f => f.ComplementServiceId == food.ComplementServiceId);
                if (foo != null)
                {
                    _context.ComplementServices.Remove(foo);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
