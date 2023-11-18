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
    public class MealRepository :IMealRepository
    {
        private readonly mealDAO dao;

        public MealRepository(MyDbContext dbContext)
        {
            dao = new mealDAO(dbContext);
        }

        public Meal createnewMeal(Meal re) =>dao.createnewRecipe(re);

        public void DeleteMeal(Meal recipeDetail)=>dao.DeleteMeal(recipeDetail);

        public List<Meal> getFoodsById(Guid foodId) =>dao.getFoodsById(foodId);

        public List<Meal> getMenusbyId(Guid menuId)=>dao.getMenusbyId(menuId);

        public void UpdateMeal(Meal recipeDetail) =>dao.UpdateMeal(recipeDetail);
    }
}
