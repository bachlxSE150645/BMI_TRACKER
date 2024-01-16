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
        List<blog> getBlogByuserId(Guid userId);
         List<blog> GetAllBlogs();
         blog getBolgById(Guid id);
         Task<blog> addNewBlog(blog blogInfo);
        public List<blog> getBlogByUser(string email);
        List<blog> GetBlogByDatime(DateTime dateForm, DateTime dateTo);
        List<blog> selectAllBlogHaveFoodTag(string tag);
        blog UpdateBlog(blog blog);
        bool deleteBlog(blog food);
    }
}
