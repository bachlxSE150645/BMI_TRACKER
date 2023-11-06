using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class blogDAO
    {
        private readonly MyDbContext _context;
        public blogDAO(MyDbContext context) { _context = context; }
        public List<blog> GetAllBlogs()
        {
            try
            {
                return _context.blogs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public blog getBolgById(Guid id)
        {
            try
            {
                return _context.blogs.Where(b => b.bolgId == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<blog> addNewBlog(blog blogInfo)
        {
            try
            {
                var newBlog = new blog
                {
                    bolgId = Guid.NewGuid(),
                    blogName = blogInfo.blogName,
                    blogContent = blogInfo.blogContent,
                    blogPhoto = blogInfo.blogPhoto,
                    link = blogInfo.link,
                    status = "available",
                };
                _context.blogs.Add(blogInfo);
                _context.SaveChanges();
                return newBlog;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public blog UpdateBlog(blog blog)
        {
            try
            {
                var blo = _context.blogs.FirstOrDefault(f => f.bolgId == blog.bolgId);
                if (blo != null)
                {
                    _context.Entry<blog>(blo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public bool deleteBlog(blog food)
        {
            try
            {
                var foo = _context.blogs.FirstOrDefault(f => f.bolgId == food.bolgId);
                if (foo != null)
                {
                    _context.blogs.Remove(foo);
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
