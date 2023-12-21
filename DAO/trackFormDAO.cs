using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class trackFormDAO
    {
        private readonly MyDbContext _context;
        public trackFormDAO(MyDbContext context) { _context = context; }
        public List<trackForm> GetTracksFromList() 
        {
            try
            {
                return _context.trackForms.Include(u=>u.users).Include(s=>s.services).ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public trackForm GetTrackFormById(Guid id)
        {
            try
            {
                return _context.trackForms.Where(t => t.trackFormId == id).Include(u=>u.users).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       public trackForm AddTrackForm(trackForm trackForm)
        {
            try
            {
                var NewTrackForm = new trackForm
                {
                    trackFormId = Guid.NewGuid(),
                    trackeFormDescription = trackForm.trackeFormDescription,
                    trackFormName = trackForm.trackFormName,
                    userId = trackForm.userId,
                    serviceId = trackForm.serviceId,
                    services = _context.services.Where(u=>u.serviceId == trackForm.serviceId).FirstOrDefault(),
                    users = _context.users.Where(u=>u.userId == trackForm.userId).FirstOrDefault(), 
                    status = "available-trackForm"
                };
                _context.trackForms.Add(NewTrackForm);
                _context.SaveChanges();
                return NewTrackForm;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public trackForm updateTrackform(Guid id,trackForm track)
        {
            try
            {
                var or = _context.trackForms.Where(b => b.trackFormId.Equals(id))
                    .Include(u => u.services).
                    Include(u => u.users).FirstOrDefault();
                or.trackFormName =track.trackFormName;
                or.trackeFormDescription = track.trackeFormDescription;
                _context.trackForms.Update(or);
                _context.SaveChanges();
                return or;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteTrackForm(trackForm feedback)
        {
            try
            {
                var check = _context.trackForms.SingleOrDefault(f => f.trackFormId == feedback.trackFormId);
                if (check != null)
                {
                    _context.trackForms.Remove(check);
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
