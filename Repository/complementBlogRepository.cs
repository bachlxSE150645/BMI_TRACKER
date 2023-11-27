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
    public class complementBlogRepository : IComplementBlogRepository
    {
        private readonly complementBlogDAO dao;

        public complementBlogRepository(MyDbContext dbContext)
        {
            dao = new complementBlogDAO(dbContext);
        }

        public complementBlog addNewCompByBlog(complementBlog comp)=>dao.addNewCompByBlog(comp);

      

        public bool deleteComplement(complementBlog food)=>dao.deleteComplement(food);

        public List<complementBlog> getaALLCompsByUserEmail(string email)=>dao.getaALLCompsByUserEmail(email);

        public List<complementBlog> GetAllComplemennts()=>dao.GetAllComplemennts();

        public complementBlog UpdateComplement(complementBlog blog)=>dao.UpdateComplement(blog);
    }
}
