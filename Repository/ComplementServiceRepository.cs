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
    public class ComplementServiceRepository :IComplementServiceRepository
    {
        private readonly complementServiceDAO dao;

        public ComplementServiceRepository(MyDbContext dbContext)
        {
            dao = new complementServiceDAO(dbContext);
        }

        public ComplementService addNewCompByService(ComplementService comp)=>dao.addNewCompByService(comp);

        public List<ComplementService> getaALLCompsByUserEmail(string email) => dao.getaALLCompsByUserEmail(email);

        public List<ComplementService> GetAllComplemennts() =>dao.GetAllComplemennts();
    }
}
