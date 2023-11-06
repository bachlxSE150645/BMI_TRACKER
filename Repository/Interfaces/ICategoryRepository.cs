using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCat();
        Category GetCategoryById(Guid id);
        Category AddCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(Category cate);

    }
}
