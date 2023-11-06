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
    public class serviceTypeRepository :IServiceTypeRepository

    {
        private readonly serviceTypeDAO dao;
        public serviceTypeRepository(MyDbContext context)
        {
            dao = new serviceTypeDAO(context);
        }

        public Task<ServiceType> addNewServiceType(ServiceType serviceT)=>dao.addNewServiceType(serviceT);
        public bool deleteServiceType(ServiceType food)=>dao.deleteServiceType(food);

        public List<ServiceType> GetAllServices()=>dao.GetAllServiceTypes();

        public ServiceType getServiceTypeById(Guid id) =>dao.getServiceTypeById(id);

        public ServiceType UpdateServiceType(ServiceType blog) =>dao.UpdateServiceType(blog);
    }
}
