
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
    public class serviceReposiotry :IServiceRepository
    {
        private readonly serviceDAO dao;
        public serviceReposiotry(MyDbContext dbContext)
        {
            dao = new serviceDAO(dbContext);
        }

        public Task<Service> addNewService(Service service) =>dao.addNewService(service);
        public bool deleteService(Service food) =>dao.deleteService(food);

        public List<Service> GetAllServices() =>dao.GetAllServices();

        public Service getServiceById(Guid id)=>dao.getServiceById(id);

        public Service UpdateService(Service blog) =>dao.UpdateService(blog);
    }
}
