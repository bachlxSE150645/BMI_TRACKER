using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class mealDAO
    {
        private readonly MyDbContext _context;
        public mealDAO(MyDbContext context)
        {
            _context = context;
        }
        public List<Meal> getFoodsById(Guid foodId)
        {
            try
            {
                var result = (from r in _context.meals
                              where (r.foodId == foodId)
                              select r).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Meal> getMenusbyId(Guid menuId)
        {
            try
            {
                var result = (from r in _context.meals
                              where (r.menuId == menuId)
                              select r).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Meal createnewRecipe(Meal re)
        {
            try
            {
                var recipeNew = new Meal
                {
                    menuId = re.menuId,
                    foodId = re.foodId,
                    foods = _context.foods.Where(f => f.foodId == re.foodId).FirstOrDefault(),
                    Menus = _context.menus.Where(f => f.MenuId == re.menuId).FirstOrDefault()
                };
                return recipeNew;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateMeal(Meal recipeDetail)
        {
            try
            {
                var recipeDetailCheck = _context.meals.SingleOrDefault(x => x.foodId == recipeDetail.foodId && x.menuId == recipeDetail.menuId);
                if (recipeDetailCheck != null)
                {
                    _context.Entry(recipeDetailCheck).CurrentValues.SetValues(recipeDetail);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Recipe Detail
        public void DeleteMeal(Meal recipeDetail)
        {
            try
            {
                var recipeDetailCheck = _context.meals.SingleOrDefault(x => x.foodId == recipeDetail.foodId && x.menuId == recipeDetail.menuId);
                if (recipeDetailCheck != null)
                {
                    _context.meals.Remove(recipeDetailCheck);
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
