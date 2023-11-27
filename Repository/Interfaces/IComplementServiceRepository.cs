using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IComplementServiceRepository
    {
        List<ComplementService> GetAllComplemennts();
        List<ComplementService> getaALLCompsByUserEmail(string email);
        ComplementService addNewCompByService(ComplementService comp);

    }
}
