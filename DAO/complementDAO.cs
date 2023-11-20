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
    public class complementDAO
    {
        private readonly MyDbContext _context;
        public complementDAO(MyDbContext context) { _context = context; }

          public  List<complement> GetAllComplemennts() 
        {
            try
            {
                return _context.Complements
                    .Include(u=>u.users)
                    .Include(b=>b.blogs)
                    .Include(s=>s.services)
                    .ToList();
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
        public complement addNewCompByBlog (complement comp)
        {
            try
            {
                var NewComp = new complement
                {
                    ratingId = Guid.NewGuid(),
                    quantity = comp.quantity,
                    blogId = comp.blogId,
                    blogs = _context.blogs.SingleOrDefault(u => u.bolgId == comp.blogId)
            };
                _context.Complements.Add(NewComp);
                _context.SaveChanges();
                return NewComp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public complement addNewCompByService(complement comp)
        {
            try
            {
                var NewComp = new complement
                {
                    ratingId = Guid.NewGuid(),
                    quantity = comp.quantity,
                    blogId = comp.blogId, 
                    serviceId = comp.serviceId,
                    services = _context.services.SingleOrDefault(u => u.serviceId == comp.serviceId)
                };
                _context.Complements.Add(NewComp);
                _context.SaveChanges();
                return NewComp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public complement addNewCompByUser(complement comp)
        {
            try
            {
                var NewComp = new complement
                {
                    ratingId = Guid.NewGuid(),
                    quantity = comp.quantity,
                    userId = comp.userId,
                    users = _context.users.SingleOrDefault(u => u.userId == comp.userId),
                };
                _context.Complements.Add(NewComp);
                _context.SaveChanges();
                return NewComp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            public complement UpdateComplement(complement blog)
        {
            try
            {
                var blo = _context.Complements.FirstOrDefault(f => f.ratingId == blog.ratingId);
                if (blo != null)
                {
                    _context.Entry<complement>(blo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public bool deleteComplement(complement food)
        {
            try
            {
                var foo = _context.Complements.FirstOrDefault(f => f.ratingId == food.ratingId);
                if (foo != null)
                {
                    _context.Complements.Remove(foo);
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
