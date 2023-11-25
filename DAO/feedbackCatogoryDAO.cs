using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class feedbackCatogoryDAO
    {

        private readonly MyDbContext _context;
        public feedbackCatogoryDAO(MyDbContext context) { _context = context; }

        public List<feebackCategory> GetFeedbackCategorys()
        {
            try
            {
                return _context.feebackCategories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get role by RoleID
        public feebackCategory GetFeedbackCategoryById(Guid id)
        {
            try
            {
                return _context.feebackCategories.SingleOrDefault(x => x.feedbackCategoryId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Role
        public feebackCategory AddFeebackCategory(feebackCategory category)
        {
            try
            {
                var newCategory = new feebackCategory
                {
                   feedbackCategoryId = category.feedbackCategoryId,
                   feedbackCategoryName = category.feedbackCategoryName,
                   status = "available-feedbackCate"
                };
                _context.feebackCategories.Add(newCategory);
                _context.SaveChanges();
                return newCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing role by Role ID
        public void UpdatefeebackCategory(feebackCategory category)
        {
            try
            {
                var cateCheck = _context.feebackCategories.SingleOrDefault(x => x.feedbackCategoryId ==category.feedbackCategoryId );
                if (cateCheck != null)
                {
                    _context.Entry(cateCheck).CurrentValues.SetValues(category);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing role
        public void DeleteFeedbackCategory(feebackCategory cate)
        {
            try
            {
                var cateCheck = _context.feebackCategories.SingleOrDefault(x => x.feedbackCategoryId == cate.feedbackCategoryId);
                if (cateCheck != null)
                {
                    _context.feebackCategories.Remove(cateCheck);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
