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
    public class ComplementRepository : IComplementRepository
    {
        private readonly complementDAO dao;

        public ComplementRepository(MyDbContext dbContext)
        {
            dao = new complementDAO(dbContext);
        }

        public complement addNewCompByBlog(complement comp)=>dao.addNewCompByBlog(comp);

        public complement addNewCompByService(complement comp)=>dao.addNewCompByService(comp);

        public complement addNewCompByUser(complement comp)=>dao.addNewCompByUser(comp);

        public bool deleteComplement(complement food)=>dao.deleteComplement(food);

        public List<complement> getaALLCompsByUserEmail(string email) =>dao.getaALLCompsByUserEmail(email);

        public List<complement> GetAllComplemennts()=>dao.GetAllComplemennts();

        public complement UpdateComplement(complement blog) =>dao.UpdateComplement(blog);
    }
}
