using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IMealRepository
    {
        List<Meal> getFoodsById(Guid foodId);
        List<Meal> getMenusbyId(Guid menuId);
        void UpdateMeal(Meal recipeDetail);
        void DeleteMeal(Meal recipeDetail);
        Meal createnewMeal(Meal re);
    }
}
