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
    public class BlogRepository :IBlogRepository
    {
        private readonly blogDAO dao;

        public BlogRepository(MyDbContext dbContext)
        {
            dao = new blogDAO(dbContext);
        }

        public Task<blog> addNewBlog(blog blogInfo) =>dao.addNewBlog(blogInfo);

        public bool deleteBlog(blog food) =>dao.deleteBlog(food);

        public List<blog> GetAllBlogs()=>dao.GetAllBlogs();
        public blog getBolgById(Guid id)=>dao.getBolgById(id);

        public List<blog> selectAllBlogHaveFoodTag(string tag) => dao.selectAllBlogHaveFoodTag(tag);

        public List<blog> getBlogByUser(string email) =>dao.getBlogByUser(email);

        public blog UpdateBlog(blog blog) =>dao.UpdateBlog(blog);

        public List<blog> GetBlogByDatime(DateTime dateForm, DateTime dateTo) => dao.GetBlogByDatime(dateForm, dateTo);
    }
}
