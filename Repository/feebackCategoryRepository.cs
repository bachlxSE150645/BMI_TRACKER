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
    public class feebackCategoryRepository  : IFeebackCategoryRepository
    {
        private readonly feedbackCatogoryDAO dao;

        public feebackCategoryRepository(MyDbContext dbContext)
        {
            dao = new feedbackCatogoryDAO(dbContext);
        }

        public feebackCategory AddFeebackCategory(feebackCategory category) =>dao.AddFeebackCategory(category);

        public void DeleteFeedbackCategory(feebackCategory cate) => dao.DeleteFeedbackCategory(cate);

        public feebackCategory GetFeedbackCategoryById(Guid id) =>dao.GetFeedbackCategoryById(id);

        public List<feebackCategory> GetFeedbackCategorys() =>dao.GetFeedbackCategorys();

        public void UpdatefeebackCategory(feebackCategory category)=>dao.UpdatefeebackCategory(category);
    }
}
