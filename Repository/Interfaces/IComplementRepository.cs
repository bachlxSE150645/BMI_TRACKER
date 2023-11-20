using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IComplementRepository
    {
        List<complement> GetAllComplemennts();
        List<complement> getaALLCompsByUserEmail(string email);
        complement addNewCompByBlog(complement comp);
        complement addNewCompByService(complement comp);
        complement addNewCompByUser(complement comp);
        public complement UpdateComplement(complement blog);
        public bool deleteComplement(complement food);
    }
}
