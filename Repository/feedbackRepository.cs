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
    public class feedbackRepository :IFeedbackRepository
    {
        private readonly feedBackDAO dao;

        public feedbackRepository(MyDbContext dbContext)
        {
            dao = new feedBackDAO(dbContext);
        }

        public feedback addFeedback(feedback feed) =>dao.addFeedback(feed);
        public bool DeleteFeedback(feedback feedback) => dao.DeleteFeedback(feedback);

        public List<feedback> getAllFeedBack() =>dao.getAllFeedBack();

        public feedback getFeedbackById(Guid id)=>dao.getFeedbackById(id);

        public feedback updateFeedback(feedback feedback) =>dao.updateFeedback(feedback);
    }
}
