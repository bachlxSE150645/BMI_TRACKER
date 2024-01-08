using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class recipeDAO
    {
        private readonly MyDbContext _context;
        public recipeDAO(MyDbContext context)
        {
            _context = context;
        }
        public List<recipe> getFoodsById(Guid foodId)
        {
            try
            {
                var result = (from r in _context.recipes
                              where (r.foodId == foodId)
                              select r).Include(i=>i.ingredients).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<recipe> getIngredientsbyId(Guid ingredientId)
        {
            try
            {
                var result = (from r in _context.recipes
                              where (r.ingredientId == ingredientId)
                              select r).Include(f=>f.foods).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public recipe createnewRecipe(recipe re)
        {
            try
            {
                var recipeNew = new recipe
                {
                    foodId = re.foodId,
                    ingredientId = re.ingredientId,
                    foods = _context.foods.Where(f => f.foodId == re.foodId).FirstOrDefault(),
                    ingredients = _context.ingredients.Where(f => f.ingredientId == re.ingredientId).FirstOrDefault()
                };
                _context.recipes.Add(recipeNew);
                _context.SaveChanges();
                return recipeNew;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateRecipe(recipe recipeDetail)
        {
            try
            {
                var recipeDetailCheck = _context.recipes.SingleOrDefault(x => x.foodId == recipeDetail.foodId && x.ingredientId == recipeDetail.ingredientId);
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
        public void DeleteRecipeDetail(recipe recipeDetail)
        {
            try
            {
                var recipeDetailCheck = _context.recipes.SingleOrDefault(x => x.foodId == recipeDetail.foodId && x.ingredientId == recipeDetail.ingredientId);
                if (recipeDetailCheck != null)
                {
                    _context.recipes.Remove(recipeDetailCheck);
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
