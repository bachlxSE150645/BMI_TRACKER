using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFeebackCategoryRepository
    {
        List<feebackCategory> GetFeedbackCategorys();
        feebackCategory GetFeedbackCategoryById(Guid id);
        feebackCategory AddFeebackCategory(feebackCategory category);
        void UpdatefeebackCategory(feebackCategory category);
        void DeleteFeedbackCategory(feebackCategory cate);

    }
}
