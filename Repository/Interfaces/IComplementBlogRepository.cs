using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IComplementBlogRepository
    {
        List<complementBlog> GetAllComplemennts();
        List<complementBlog> getaALLCompsByUserEmail(string email);
        complementBlog addNewCompByBlog(complementBlog comp);
        public complementBlog UpdateComplement(complementBlog blog);
        public bool deleteComplement( complementBlog food);
    }
}
