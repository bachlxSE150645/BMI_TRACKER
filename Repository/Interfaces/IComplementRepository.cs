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
    }
}
