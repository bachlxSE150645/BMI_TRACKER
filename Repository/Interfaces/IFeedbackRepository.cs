using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFeedbackRepository
    {
        List<feedback> getAllFeedBack();
        feedback getFeedbackById(Guid id);
        feedback addFeedback(feedback feed);
        feedback updateFeedback(feedback feedback);
        bool DeleteFeedback(feedback feedback);
    }
}
