using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class serviceTypeDAO
    {
        private readonly MyDbContext _context;
        public serviceTypeDAO(MyDbContext context) { _context = context; }
        public List<ServiceType> GetAllServiceTypes()
        {
            try
            {
                return _context.serviceTypes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ServiceType getServiceTypeById(Guid id)
        {
            try
            {
                return _context.serviceTypes.Where(b => b.ServiceTypeId == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ServiceType> addNewServiceType(ServiceType serviceT)
        {
            try
            {
                var newBlog = new ServiceType
                {
                    ServiceTypeId = Guid.NewGuid(),
                    nameServiceType = serviceT.nameServiceType,
                    textServiceType = serviceT.textServiceType,
                     
                    status = "available",
                };
                _context.serviceTypes.Add(serviceT);
                _context.SaveChanges();
                return newBlog;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ServiceType UpdateServiceType(ServiceType blog)
        {
            try
            {
                var blo = _context.serviceTypes.FirstOrDefault(f => f.ServiceTypeId == blog.ServiceTypeId);
                if (blo != null)
                {
                    _context.Entry<ServiceType>(blo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return blo;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool deleteServiceType(ServiceType food)
        {
            try
            {
                var foo = _context.serviceTypes.FirstOrDefault(f => f.ServiceTypeId == food.ServiceTypeId);
                if (foo != null)
                {
                    _context.serviceTypes.Remove(foo);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
