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

        public List<complement> getaALLCompsByUserEmail(string email) =>dao.getaALLCompsByUserEmail(email);

        public List<complement> GetAllComplemennts()=>dao.GetAllComplemennts();
    }
}
