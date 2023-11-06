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
    public class categoryRepository :ICategoryRepository
    {
        private readonly categoryDAO dao;

        public categoryRepository(MyDbContext dbContext)
        {
            dao = new categoryDAO(dbContext);
        }

        public Category AddCategory(Category category) =>dao.AddCategory(category);

        public void DeleteCategory(Category cate) =>dao.DeleteCategory(cate);

        public List<Category> GetCat()=>dao.GetCat();

        public Category GetCategoryById(Guid id)=>dao.GetCategoryById(id);

        public void UpdateCategory(Category category) =>dao.UpdateCategory(category);
    }
}
