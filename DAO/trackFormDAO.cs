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
                return _context.trackForms.Include(u=>u.users).ToList();
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
                    isTracked = trackForm.isTracked,
                    userId = trackForm.userId,
                    users = _context.users.Where(u=>u.userId == trackForm.users.userId).FirstOrDefault(), 
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
        public trackForm updateTrackform(trackForm feedback)
        {
            try
            {
                var check = _context.trackForms.SingleOrDefault(f => f.trackFormId == feedback.trackFormId);
                if (check != null)
                {
                    _context.Entry<trackForm>(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                }
                return check;
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
