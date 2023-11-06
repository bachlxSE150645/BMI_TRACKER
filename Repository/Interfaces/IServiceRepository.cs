using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IServiceRepository
    {
        List<Service> GetAllServices();
        Service getServiceById(Guid id);
        Task<Service> addNewService(Service service);
        Service UpdateService(Service blog);
        bool deleteService(Service food);

    }
}
