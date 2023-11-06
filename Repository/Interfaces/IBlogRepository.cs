using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBlogRepository
    {
         List<blog> GetAllBlogs();
         blog getBolgById(Guid id);
         Task<blog> addNewBlog(blog blogInfo);
        blog UpdateBlog(blog blog);
        bool deleteBlog(blog food);
    }
}
