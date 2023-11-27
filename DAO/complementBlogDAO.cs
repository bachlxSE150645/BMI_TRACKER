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
    public class complementBlogDAO
    {
        private readonly MyDbContext _context;
        public complementBlogDAO(MyDbContext context) { _context = context; }

          public  List<complementBlog> GetAllComplemennts() 
        {
            try
            {
                return _context.ComplementBlogs
                    .Include(u=>u.users)
                    .Include(b=>b.blogs)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<complementBlog> getaALLCompsByUserEmail(string email)
        {
            try
            {
                var comp = from c in _context.ComplementBlogs
                           where c.users.email.Contains(email)
                           select c;
                return comp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public complementBlog addNewCompByBlog (complementBlog comp)
        {
            try
            {
                var NewComp = new complementBlog
                {
                    complementBlogId = Guid.NewGuid(),
                    quantity = comp.quantity,
                    blogId = comp.blogId,
                    
                    userId = comp.userId,
                    users = _context.users.SingleOrDefault(u => u.userId == comp.userId),
                    blogs = _context.blogs.SingleOrDefault(u => u.bolgId == comp.blogId),
                    status = "available-com-blog"
                };
                _context.ComplementBlogs.Add(NewComp);
                _context.SaveChanges();
                return NewComp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
       
            public complementBlog UpdateComplement(complementBlog blog)
        {
            try
            {
                var blo = _context.ComplementBlogs.FirstOrDefault(f => f.complementBlogId == blog.complementBlogId);
                if (blo != null)
                {
                    _context.Entry<complementBlog>(blo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public bool deleteComplement(complementBlog food)
        {
            try
            {
                var foo = _context.ComplementBlogs.FirstOrDefault(f => f.complementBlogId == food.complementBlogId);
                if (foo != null)
                {
                    _context.ComplementBlogs.Remove(foo);
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
