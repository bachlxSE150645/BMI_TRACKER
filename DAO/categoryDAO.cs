using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class categoryDAO
    {

        private readonly MyDbContext _context;
        public categoryDAO(MyDbContext context) { _context = context; }

        public List<Category> GetCat()
        {
            try
            {
                return _context.categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get role by RoleID
        public Category GetCategoryById(Guid id)
        {
            try
            {
                return _context.categories.SingleOrDefault(x => x.CategoryId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Role
        public Category AddCategory(Category category)
        {
            try
            {
                var newCategory = new Category
                {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = category.CategoryName
                };
                _context.categories.Add(newCategory);
                _context.SaveChanges();
                return newCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing role by Role ID
        public void UpdateCategory(Category category)
        {
            try
            {
                var cateCheck = _context.categories.SingleOrDefault(x => x.CategoryId ==category.CategoryId );
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
        public void DeleteCategory(Category cate)
        {
            try
            {
                var cateCheck = _context.categories.SingleOrDefault(x => x.CategoryId == cate.CategoryId);
                if (cateCheck != null)
                {
                    _context.categories.Remove(cateCheck);
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
