using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IServiceTypeRepository
    {
        List<ServiceType> GetAllServices();
        ServiceType getServiceTypeById(Guid id);
        Task<ServiceType> addNewServiceType(ServiceType serviceT);
        ServiceType UpdateServiceType(ServiceType blog);
        bool deleteServiceType(ServiceType food);
    }
}
