using BussinessObject;
using BussinessObject.MapData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class feedBackDAO
    {
        private readonly MyDbContext _context;
        public feedBackDAO(MyDbContext dbContext)
        {
            _context = dbContext;
        }
        public List<feedback> getAllFeedBack()
        {
            try
            {
                return _context.feedbacks.Include(x => x.users).Include(u=>u.users.roles.roleName).ToList();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public feedback getFeedbackById(Guid id)
        {
            try
            {
                return _context.feedbacks.Where(feed => feed.feedbackId == id).Include(f => f.users).Include(r=>r.users.roles.roleName).FirstOrDefault();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public feedback addFeedback(feedback feed)
        {
            try
            {
                var newFeedback = new feedback
                {
                    feedbackId = Guid.NewGuid(),
                    title = feed.title,
                    description = feed.description,
                    userId = feed.userId,
                    status = "available-feedback",
                    users = _context.users.Where(u=>u.userId == feed.userId).FirstOrDefault(),
                    feebackCategoryId  =  feed.feebackCategoryId,
                    feebackCategorys =_context.feebackCategories.FirstOrDefault(f=>f.feedbackCategoryId ==feed.feebackCategoryId)
                };
                _context.feedbacks.Add(newFeedback);
                _context.SaveChanges();
                return newFeedback;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public feedback updateFeedback(feedback feedback)
        {
            try
            {
                var check = _context.feedbacks.SingleOrDefault(f => f.feedbackId == feedback.feedbackId);
                if(check != null)
                {
                    _context.Entry<feedback>(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    
                }
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteFeedback (feedback feedback)
        {
            try
            {
                var check = _context.feedbacks.SingleOrDefault(f=>f.feedbackId == feedback.feedbackId);
                if(check != null)
                {
                    _context.feedbacks.Remove(check);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }
    } 
}

