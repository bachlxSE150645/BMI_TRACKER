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
    public class recipeRepository :IRecipeRepository
    {
        private readonly recipeDAO dao;

        public recipeRepository(MyDbContext dbContext)
        {
            dao = new recipeDAO(dbContext);
        }

        public recipe createnewRecipe(recipe re)=>dao.createnewRecipe(re);

        public void DeleteRecipeDetail(recipe recipeDetail)=>dao.DeleteRecipeDetail(recipeDetail);

        public List<recipe> getFoodsById(Guid foodId) =>dao.getFoodsById(foodId);

        public List<recipe> getIngredientsById(Guid ingId)=>dao.getIngredientsbyId(ingId);

        public void UpdateRecipe(recipe recipeDetail)=>dao.UpdateRecipe(recipeDetail);
    }
}
