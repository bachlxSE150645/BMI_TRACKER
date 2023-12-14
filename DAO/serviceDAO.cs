using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class serviceDAO
    {
        private readonly MyDbContext _context;
        public serviceDAO(MyDbContext context) { _context = context; }
        public List<Service> GetAllServices()
        {
            try
            {
                return _context.services.Include(u=>u.users).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Service getServiceById(Guid id)
        {
            try
            {
                return _context.services.Include(u=>u.users).Where(b => b.serviceId == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Service> addNewService(Service service)
        {
            try
            {
                var newService = new Service
                {
                    serviceId = Guid.NewGuid(),
                    nameService = service.nameService,
                    descriptionService = service.descriptionService,
                    userId = service.userId,
                    users = _context.users.Where(s=>s.userId == service.userId).FirstOrDefault(),
                    status = "available-service",
                };
                _context.services.Add(newService);
               await _context.SaveChangesAsync();
                return newService;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Service UpdateService(Service blog)
        {
            try
            {
                var blo = _context.services.FirstOrDefault(f => f.serviceId == blog.serviceId);
                if (blo != null)
                {
                    _context.Entry<Service>(blo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public bool deleteService(Service food)
        {
            try
            {
                var foo = _context.services.FirstOrDefault(f => f.serviceId == food.serviceId);
                if (foo != null)
                {
                    _context.services.Remove(foo);
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
